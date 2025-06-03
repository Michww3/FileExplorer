using FileExplorer.Config;
using FileExplorer.Helpers;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        private SemaphoreSlim semaphore = new SemaphoreSlim(1000, 1000);
        private ConcurrentQueue<FileInfo> fileQueue = new ConcurrentQueue<FileInfo>();
        private System.Threading.Timer uiTimer;

        public Form1()
        {
            InitializeComponent();

            DirectoryTextBox.Text = MainForm.LoadDirectoryFromRegistry();       

            uiTimer = new System.Threading.Timer(UpdateDataGridView, null, 0, 100);
        }
        private void DirectorySaveButton_Click(object sender, EventArgs e)
        {
            MainForm.SaveDirectoryToRegistry(DirectoryTextBox.Text);
        }

        private void LoadFilesButton_Click(object sender, EventArgs e)
        {
            string extension = FileExtensionLabel.Text.Trim();
            string directoryPath = DirectoryTextBox.Text;

            if (!Directory.Exists(directoryPath))
            {
                MessageBox.Show(Strings.DirectoryNotFound);
                return;
            }

            FilesDataGridView.Invoke(new Action(() => FilesDataGridView.Rows.Clear()));
            fileQueue = new ConcurrentQueue<FileInfo>();

            ThreadPool.QueueUserWorkItem(_ => MainForm.SearchFiles(directoryPath, fileQueue, semaphore, extension));
        }
        private void UpdateDataGridView(object state)
        {
            if (FilesDataGridView.IsHandleCreated && !FilesDataGridView.IsDisposed)
            {
                FilesDataGridView.Invoke(new Action(() =>
                {
                    int maxItems = 30;
                    int count = 0;

                    while (count < maxItems && fileQueue.TryDequeue(out var fileInfo))
                    {
                        Bitmap bmp = ImageToDataGrid.GetFileIcon(fileInfo.FullName).ToBitmap();

                        FilesDataGridView.Rows.Add(
                            bmp,
                            fileInfo.Name,
                            fileInfo.FullName,
                            fileInfo.Length / 1024,
                            fileInfo.CreationTime,
                            fileInfo.LastWriteTime,
                            fileInfo.Extension
                        );
                        count++;
                    }
                }));
            }
        }

    }
}
