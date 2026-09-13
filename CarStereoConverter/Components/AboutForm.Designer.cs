namespace CarStereoConverter
{
    partial class AboutForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            pictureBoxIcon = new PictureBox();
            lblAppName = new Label();
            lblVersion = new Label();
            lblAuthor = new Label();
            linkGitHub = new LinkLabel();
            btnOk = new Button();
            aboutLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Location = new Point(20, 20);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(48, 48);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxIcon.TabIndex = 0;
            pictureBoxIcon.TabStop = false;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAppName.Location = new Point(84, 20);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(167, 21);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "Car Stereo Converter";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(85, 50);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(71, 15);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "Versão: 1.0.0";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(85, 72);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(73, 15);
            lblAuthor.TabIndex = 3;
            lblAuthor.Text = "Autor: Paulo";
            // 
            // linkGitHub
            // 
            linkGitHub.AutoSize = true;
            linkGitHub.Location = new Point(20, 254);
            linkGitHub.Name = "linkGitHub";
            linkGitHub.Size = new Size(263, 15);
            linkGitHub.TabIndex = 4;
            linkGitHub.TabStop = true;
            linkGitHub.Text = "https://github.com/paulosrlj/mp3-to-car-sound";
            linkGitHub.LinkClicked += linkGitHub_LinkClicked;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(319, 300);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(90, 30);
            btnOk.TabIndex = 5;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // aboutLabel
            // 
            aboutLabel.AutoSize = true;
            aboutLabel.Location = new Point(12, 118);
            aboutLabel.Name = "aboutLabel";
            aboutLabel.Size = new Size(381, 75);
            aboutLabel.TabIndex = 6;
            aboutLabel.Text = resources.GetString("aboutLabel.Text");
            //aboutLabel.Click += this.aboutLabel_Click;
            // 
            // AboutForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 355);
            Controls.Add(aboutLabel);
            Controls.Add(btnOk);
            Controls.Add(linkGitHub);
            Controls.Add(lblAuthor);
            Controls.Add(lblVersion);
            Controls.Add(lblAppName);
            Controls.Add(pictureBoxIcon);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sobre";
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxIcon;
        private Label lblAppName;
        private Label lblVersion;
        private Label lblAuthor;
        private LinkLabel linkGitHub;
        private Button btnOk;
        private Label aboutLabel;
    }
}