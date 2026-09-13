namespace CarStereoConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConvert = new Button();
            label1 = new Label();
            panelDropArea = new Panel();
            btn_select_files = new Button();
            label2 = new Label();
            txtOutputFolder = new TextBox();
            label3 = new Label();
            button2 = new Button();
            dgvFiles = new DataGridView();
            file_clm = new DataGridViewTextBoxColumn();
            size_clm = new DataGridViewTextBoxColumn();
            status_clm = new DataGridViewTextBoxColumn();
            progress_clm = new DataGridViewTextBoxColumn();
            label4 = new Label();
            lblStatus = new Label();
            panelDropArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFiles).BeginInit();
            SuspendLayout();
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(16, 589);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(491, 85);
            btnConvert.TabIndex = 0;
            btnConvert.Text = "Converter";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(133, 15);
            label1.TabIndex = 1;
            label1.Text = "Arquivos para converter";
            label1.Click += label1_Click;
            // 
            // panelDropArea
            // 
            panelDropArea.AllowDrop = true;
            panelDropArea.BorderStyle = BorderStyle.Fixed3D;
            panelDropArea.Controls.Add(btn_select_files);
            panelDropArea.Controls.Add(label2);
            panelDropArea.Location = new Point(12, 70);
            panelDropArea.Name = "panelDropArea";
            panelDropArea.Size = new Size(491, 107);
            panelDropArea.TabIndex = 0;
            panelDropArea.DragDrop += pnlDropArea_DragDrop;
            panelDropArea.DragEnter += panelDropArea_DragEnter;
            panelDropArea.Paint += panel1_Paint;
            // 
            // btn_select_files
            // 
            btn_select_files.Location = new Point(167, 62);
            btn_select_files.Name = "btn_select_files";
            btn_select_files.Size = new Size(157, 31);
            btn_select_files.TabIndex = 1;
            btn_select_files.Text = "[ Selecionar arquivos ]";
            btn_select_files.UseVisualStyleBackColor = true;
            btn_select_files.Click += btnSelectFiles_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(155, 12);
            label2.Name = "label2";
            label2.Size = new Size(182, 15);
            label2.TabIndex = 0;
            label2.Text = "Arraste os arquivos de áudio aqui";
            // 
            // txtOutputFolder
            // 
            txtOutputFolder.Location = new Point(12, 246);
            txtOutputFolder.Name = "txtOutputFolder";
            txtOutputFolder.Size = new Size(382, 23);
            txtOutputFolder.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 214);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 3;
            label3.Text = "Pasta de saída";
            // 
            // button2
            // 
            button2.Location = new Point(400, 246);
            button2.Name = "button2";
            button2.Size = new Size(103, 23);
            button2.TabIndex = 2;
            button2.Text = "Procurar...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // dgvFiles
            // 
            dgvFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFiles.Columns.AddRange(new DataGridViewColumn[] { file_clm, size_clm, status_clm, progress_clm });
            dgvFiles.Location = new Point(16, 336);
            dgvFiles.Name = "dgvFiles";
            dgvFiles.Size = new Size(495, 196);
            dgvFiles.TabIndex = 4;
            dgvFiles.CellContentClick += dgvFiles_CellContentClick;
            // 
            // file_clm
            // 
            file_clm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            file_clm.HeaderText = "File";
            file_clm.Name = "file_clm";
            // 
            // size_clm
            // 
            size_clm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            size_clm.HeaderText = "Pasta";
            size_clm.Name = "size_clm";
            // 
            // status_clm
            // 
            status_clm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            status_clm.HeaderText = "Status";
            status_clm.Name = "Status";
            // 
            // progress_clm
            // 
            progress_clm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            progress_clm.HeaderText = "Progress";
            progress_clm.Name = "Progresso";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 296);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 5;
            label4.Text = "Arquivos";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(16, 545);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(220, 15);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Arquivos: 0 | Concluídos: 0 | Erros: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 705);
            Controls.Add(lblStatus);
            Controls.Add(label4);
            Controls.Add(dgvFiles);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(txtOutputFolder);
            Controls.Add(panelDropArea);
            Controls.Add(label1);
            Controls.Add(btnConvert);
            Name = "Form1";
            Text = "Car Stereo normalizer";
            Load += Form1_Load;
            panelDropArea.ResumeLayout(false);
            panelDropArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFiles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConvert;
        private Label label1;
        private Panel panelDropArea;
        private Button btn_select_files;
        private Label label2;
        private TextBox txtOutputFolder;
        private Label label3;
        private Button button2;
        private DataGridView dgvFiles;
        private Label label4;
        private Label lblStatus;
        private DataGridViewTextBoxColumn file_clm;
        private DataGridViewTextBoxColumn size_clm;
        private DataGridViewTextBoxColumn status_clm;
        private DataGridViewTextBoxColumn progress_clm;
    }
}
