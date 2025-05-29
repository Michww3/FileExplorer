namespace FileExplorer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DirectoryTextBox = new System.Windows.Forms.TextBox();
            this.DirectorySaveLabel = new System.Windows.Forms.Label();
            this.FilesDataGridView = new System.Windows.Forms.DataGridView();
            this.FileImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeInKb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastModifed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirectorySaveButton = new System.Windows.Forms.Button();
            this.LoadFilesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FilesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DirectoryTextBox
            // 
            this.DirectoryTextBox.Location = new System.Drawing.Point(15, 44);
            this.DirectoryTextBox.Name = "DirectoryTextBox";
            this.DirectoryTextBox.Size = new System.Drawing.Size(170, 20);
            this.DirectoryTextBox.TabIndex = 0;
            // 
            // DirectorySaveLabel
            // 
            this.DirectorySaveLabel.AutoSize = true;
            this.DirectorySaveLabel.Location = new System.Drawing.Point(12, 16);
            this.DirectorySaveLabel.Name = "DirectorySaveLabel";
            this.DirectorySaveLabel.Size = new System.Drawing.Size(173, 13);
            this.DirectorySaveLabel.TabIndex = 1;
            this.DirectorySaveLabel.Text = "Введите директорию для поиска";
            // 
            // FilesDataGridView
            // 
            this.FilesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FilesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileImage,
            this.FileName,
            this.FullPath,
            this.SizeInKb,
            this.CreationTime,
            this.LastModifed,
            this.FileExtension});
            this.FilesDataGridView.Dock = System.Windows.Forms.DockStyle.Right;
            this.FilesDataGridView.Location = new System.Drawing.Point(191, 0);
            this.FilesDataGridView.Name = "FilesDataGridView";
            this.FilesDataGridView.Size = new System.Drawing.Size(1713, 1041);
            this.FilesDataGridView.TabIndex = 2;
            // 
            // FileImage
            // 
            this.FileImage.HeaderText = "";
            this.FileImage.Name = "FileImage";
            // 
            // FileName
            // 
            this.FileName.HeaderText = "Имя файла";
            this.FileName.Name = "FileName";
            // 
            // FullPath
            // 
            this.FullPath.HeaderText = "Полный путь";
            this.FullPath.Name = "FullPath";
            // 
            // SizeInKb
            // 
            this.SizeInKb.HeaderText = "Размер (КВ)";
            this.SizeInKb.Name = "SizeInKb";
            // 
            // CreationTime
            // 
            this.CreationTime.HeaderText = "Время создания";
            this.CreationTime.Name = "CreationTime";
            // 
            // LastModifed
            // 
            this.LastModifed.HeaderText = "Последнее изменение";
            this.LastModifed.Name = "LastModifed";
            // 
            // FileExtension
            // 
            this.FileExtension.HeaderText = "Расширение";
            this.FileExtension.Name = "FileExtension";
            // 
            // DirectorySaveButton
            // 
            this.DirectorySaveButton.Location = new System.Drawing.Point(12, 70);
            this.DirectorySaveButton.Name = "DirectorySaveButton";
            this.DirectorySaveButton.Size = new System.Drawing.Size(75, 23);
            this.DirectorySaveButton.TabIndex = 3;
            this.DirectorySaveButton.Text = "Сохранить";
            this.DirectorySaveButton.UseVisualStyleBackColor = true;
            this.DirectorySaveButton.Click += new System.EventHandler(this.DirectorySaveButton_Click);
            // 
            // LoadFilesButton
            // 
            this.LoadFilesButton.Location = new System.Drawing.Point(15, 113);
            this.LoadFilesButton.Name = "LoadFilesButton";
            this.LoadFilesButton.Size = new System.Drawing.Size(170, 71);
            this.LoadFilesButton.TabIndex = 5;
            this.LoadFilesButton.Text = "Поиск файлов в директории";
            this.LoadFilesButton.UseVisualStyleBackColor = true;
            this.LoadFilesButton.Click += new System.EventHandler(this.LoadFilesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.LoadFilesButton);
            this.Controls.Add(this.DirectorySaveButton);
            this.Controls.Add(this.FilesDataGridView);
            this.Controls.Add(this.DirectorySaveLabel);
            this.Controls.Add(this.DirectoryTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.FilesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DirectoryTextBox;
        private System.Windows.Forms.Label DirectorySaveLabel;
        private System.Windows.Forms.DataGridView FilesDataGridView;
        private System.Windows.Forms.Button DirectorySaveButton;
        private System.Windows.Forms.Button LoadFilesButton;
        private System.Windows.Forms.DataGridViewImageColumn FileImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeInKb;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastModifed;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileExtension;
    }
}

