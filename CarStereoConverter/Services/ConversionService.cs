using System.Diagnostics;
using System.Globalization;

namespace CarStereoConverter.Services
{
    internal class ConversionService
    {
        private readonly string _ffmpegPath;
        private readonly string _ffprobePath;

        public ConversionService(
            string ffmpegPath,
            string ffprobePath)
        {
            _ffmpegPath = ffmpegPath;
            _ffprobePath = ffprobePath;
        }

        public async Task ConvertAsync(
            string inputFile,
            string outputFile,
            IProgress<int>? progress = null)
        {
            double duration =
                await GetDurationAsync(inputFile);

            string arguments =
                $"-y " +
                $"-i \"{inputFile}\" " +
                $"-map 0:a:0 " +
                $"-vn " +
                $"-map_metadata -1 " +
                $"-c:a libmp3lame " +
                $"-b:a 320k " +
                $"-progress pipe:1 " +
                $"-nostats " +
                $"\"{outputFile}\"";

            using var process = new Process();

            process.StartInfo = new ProcessStartInfo
            {
                FileName = _ffmpegPath,
                Arguments = arguments,

                UseShellExecute = false,

                RedirectStandardOutput = true,
                RedirectStandardError = true,

                CreateNoWindow = true
            };

            process.Start();

            // Consumir stderr para evitar que o buffer
            // do processo fique cheio.
            Task<string> errorTask =
                process.StandardError.ReadToEndAsync();

            while (!process.StandardOutput.EndOfStream)
            {
                string? line =
                    await process.StandardOutput
                        .ReadLineAsync();

                if (line == null)
                    continue;

                if (line.StartsWith("out_time_ms="))
                {
                    string value =
                        line["out_time_ms=".Length..];

                    if (long.TryParse(
                        value,
                        out long timeMicroseconds))
                    {
                        double currentSeconds =
                            timeMicroseconds / 1_000_000.0;

                        if (duration > 0)
                        {
                            int percent =
                                (int)(
                                    currentSeconds /
                                    duration *
                                    100
                                );

                            percent = Math.Clamp(
                                percent,
                                0,
                                100
                            );

                            progress?.Report(percent);
                        }
                    }
                }
            }

            await process.WaitForExitAsync();

            string error =
                await errorTask;

            if (process.ExitCode != 0)
            {
                throw new Exception(
                    $"FFmpeg falhou.\n\n{error}"
                );
            }

            progress?.Report(100);
        }

        private async Task<double> GetDurationAsync(
            string inputFile)
        {
            using var process = new Process();

            process.StartInfo = new ProcessStartInfo
            {
                FileName = _ffprobePath,

                Arguments =
                    $"-v error " +
                    $"-show_entries format=duration " +
                    $"-of default=noprint_wrappers=1:nokey=1 " +
                    $"\"{inputFile}\"",

                UseShellExecute = false,

                RedirectStandardOutput = true,
                RedirectStandardError = true,

                CreateNoWindow = true
            };

            process.Start();

            string output =
                await process.StandardOutput
                    .ReadToEndAsync();

            await process.WaitForExitAsync();

            if (double.TryParse(
                output.Trim(),
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double duration))
            {
                return duration;
            }

            return 0;
        }
    }
}
