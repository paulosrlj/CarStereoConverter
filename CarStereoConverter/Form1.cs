using CarStereoConverter.Models;
using CarStereoConverter.Services;

namespace CarStereoConverter
{
    public partial class Form1 : Form
    {
        private readonly List<AudioFile> loaded_files = new();

        private string outputFolder = "";

        public Form1()
        {
            InitializeComponent();

            SetupDragAndDrop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // =========================================================
        // DRAG & DROP
        // =========================================================

        private void SetupDragAndDrop()
        {
            EnableDragDrop(panelDropArea);
        }

        private void EnableDragDrop(Control control)
        {
            control.AllowDrop = true;

            control.DragEnter += panelDropArea_DragEnter;
            control.DragDrop += pnlDropArea_DragDrop;

            foreach (Control child in control.Controls)
            {
                EnableDragDrop(child);
            }
        }

        private void panelDropArea_DragEnter(
            object sender,
            DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pnlDropArea_DragDrop(
            object sender,
            DragEventArgs e)
        {
            if (!e.Data!.GetDataPresent(DataFormats.FileDrop))
                return;

            var files = (string[])e.Data.GetData(
                DataFormats.FileDrop
            )!;

            AddFiles(files);
        }

        // =========================================================
        // SELECIONAR ARQUIVOS
        // =========================================================

        private void btnSelectFiles_Click(
            object sender,
            EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Multiselect = true,

                Filter =
                    "Arquivos de áudio|" +
                    "*.mp3;*.wav;*.flac;*.m4a;*.aac;*.ogg"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                AddFiles(dialog.FileNames);
            }
        }

        // =========================================================
        // ADICIONAR ARQUIVOS
        // =========================================================

        private void AddFiles(IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                if (!IsSupportedAudioFile(file))
                    continue;

                // Evita adicionar o mesmo arquivo duas vezes
                if (loaded_files.Any(x =>
                    string.Equals(
                        x.InputPath,
                        file,
                        StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }

                string folder = Path.GetDirectoryName(file)!;

                string folderName =
                    new DirectoryInfo(folder).Name;

                string fileName =
                    Path.GetFileName(file);

                var audioFile = new AudioFile
                {
                    InputPath = file,
                    FileName = fileName,
                    FolderName = folderName,
                    Status = "Aguardando",
                    Progress = 0
                };

                loaded_files.Add(audioFile);

                dgvFiles.Rows.Add(
                    audioFile.FileName,
                    audioFile.FolderName,
                    audioFile.Status,
                    $"{audioFile.Progress}%"
                );
            }

            UpdateTotalStatus();
        }

        private bool IsSupportedAudioFile(string file)
        {
            string extension =
                Path.GetExtension(file)
                    .ToLowerInvariant();

            return extension is
                ".mp3" or
                ".wav" or
                ".flac" or
                ".m4a" or
                ".aac" or
                ".ogg";
        }

        // =========================================================
        // PASTA DE SAÍDA
        // =========================================================

        private void button2_Click_1(
            object sender,
            EventArgs e)
        {
            using var dialog = new FolderBrowserDialog
            {
                Description = "Selecione a pasta de saída"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                outputFolder = dialog.SelectedPath;

                txtOutputFolder.Text = outputFolder;
            }
        }

        // =========================================================
        // CONVERSÃO
        // =========================================================

        private async void btnConvert_Click(
            object sender,
            EventArgs e)
        {
            if (loaded_files.Count == 0)
            {
                MessageBox.Show(
                    "Adicione pelo menos um arquivo de áudio.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (string.IsNullOrWhiteSpace(outputFolder))
            {
                MessageBox.Show(
                    "Selecione uma pasta de saída.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            btnConvert.Enabled = false;

            try
            {
                string ffmpegPath =
                    Path.Combine(
                        Application.StartupPath,
                        "ffmpeg",
                        "ffmpeg.exe"
                    );

                string ffprobePath =
                    Path.Combine(
                        Application.StartupPath,
                        "ffmpeg",
                        "ffprobe.exe"
                    );

                if (!File.Exists(ffmpegPath))
                {
                    MessageBox.Show(
                        $"FFmpeg não encontrado:\n{ffmpegPath}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                if (!File.Exists(ffprobePath))
                {
                    MessageBox.Show(
                        $"FFprobe não encontrado:\n{ffprobePath}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                var converter = new ConversionService(
                    ffmpegPath,
                    ffprobePath
                );

                for (int i = 0; i < loaded_files.Count; i++)
                {
                    AudioFile audioFile =
                        loaded_files[i];

                    string outputDirectory =
                        Path.Combine(
                            outputFolder,
                            audioFile.FolderName
                        );

                    Directory.CreateDirectory(
                        outputDirectory
                    );

                    string originalName =
                        Path.GetFileNameWithoutExtension(
                            audioFile.InputPath
                        );

                    string outputFile =
                        Path.Combine(
                            outputDirectory,
                            $"{originalName}_320kbps.mp3"
                        );

                    audioFile.OutputPath = outputFile;

                    UpdateFileStatus(
                        i,
                        "Convertendo",
                        0
                    );

                    try
                    {
                        var progress =
                            new Progress<int>(percent =>
                            {
                                UpdateFileStatus(
                                    i,
                                    "Convertendo",
                                    percent
                                );
                            });

                        await converter.ConvertAsync(
                            audioFile.InputPath,
                            audioFile.OutputPath,
                            progress
                        );

                        UpdateFileStatus(
                            i,
                            "Concluído",
                            100
                        );
                    }
                    catch (Exception ex)
                    {
                        UpdateFileStatus(
                            i,
                            "Erro",
                            0
                        );

                        Console.WriteLine(
                            $"Erro em {audioFile.FileName}: {ex.Message}"
                        );
                    }
                }

                UpdateTotalStatus();

                MessageBox.Show(
                    "Conversão concluída.",
                    "Concluído",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            finally
            {
                btnConvert.Enabled = true;
            }
        }

        // =========================================================
        // ATUALIZAR GRID
        // =========================================================

        private void UpdateFileStatus(
            int index,
            string status,
            int progress)
        {
            if (index < 0 ||
                index >= loaded_files.Count)
            {
                return;
            }

            AudioFile audioFile =
                loaded_files[index];

            audioFile.Status = status;
            audioFile.Progress = progress;

            if (index < dgvFiles.Rows.Count)
            {
                dgvFiles.Rows[index]
                    .Cells["Status"]
                    .Value = status;

                dgvFiles.Rows[index]
                    .Cells["Progresso"]
                    .Value = $"{progress}%";
            }

            UpdateTotalStatus();
        }

        private void UpdateTotalStatus()
        {
            int total = loaded_files.Count;

            int completed = loaded_files.Count(
                x => x.Status == "Concluído"
            );

            int errors = loaded_files.Count(
                x => x.Status == "Erro"
            );

            if (lblStatus != null)
            {
                lblStatus.Text =
                    $"Arquivos: {total} | " +
                    $"Concluídos: {completed} | " +
                    $"Erros: {errors}";
            }
        }

        // =========================================================
        // SOBRE
        // =========================================================

        private void mnuSobre_Click(
            object sender,
            EventArgs e)
        {
            using var about = new AboutForm();
            about.ShowDialog(this);
        }

        // =========================================================
        // EVENTOS NÃO UTILIZADOS
        // =========================================================

        private void panel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void dgvFiles_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void label1_Click(
            object sender,
            EventArgs e)
        {
        }
    }
}