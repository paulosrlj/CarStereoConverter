using System;
using System.Collections.Generic;
using System.Text;

namespace CarStereoConverter.Models
{
    internal class AudioFile
    {
        public string InputPath { get; set; } = "";
        public string OutputPath { get; set; } = "";
        public string FileName { get; set; } = "";
        public string FolderName { get; set; } = "";
        public string Status { get; set; } = "Aguardando";
        public int Progress { get; set; }
    }
}
