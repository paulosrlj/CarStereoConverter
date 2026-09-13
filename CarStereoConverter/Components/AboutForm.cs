using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CarStereoConverter
{
    public partial class AboutForm : Form
    {
        private const string GitHubUrl =
            "https://github.com/paulosrlj/mp3-to-car-sound";

        public AboutForm()
        {
            InitializeComponent();

            lblAppName.Text = Application.ProductName;
            lblVersion.Text = $"Versão: {Application.ProductVersion}";
            lblAuthor.Text = "Autor: Paulo (paulosrlj)";
            linkGitHub.Text = GitHubUrl;

            pictureBoxIcon.Image = LoadAppIcon();
        }

        private static Image LoadAppIcon()
        {
            try
            {
                using Icon? icon =
                    Icon.ExtractAssociatedIcon(
                        Application.ExecutablePath
                    );

                if (icon != null)
                {
                    return icon.ToBitmap();
                }
            }
            catch
            {
                // Se não conseguir extrair o ícone do .exe,
                // cai no ícone padrão do sistema abaixo.
            }

            return SystemIcons.Application.ToBitmap();
        }

        private void linkGitHub_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = GitHubUrl,
                        UseShellExecute = true
                    }
                );
            }
            catch
            {
                MessageBox.Show(
                    $"Não foi possível abrir o link.\n{GitHubUrl}",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}