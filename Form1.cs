using FileExplorer.Helpers;
using Microsoft.Win32;
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
        private SemaphoreSlim semaphore = new SemaphoreSlim(1000, 1000); // ограничение по параллельным задачам
        private ConcurrentQueue<FileInfo> fileQueue = new ConcurrentQueue<FileInfo>();
        private System.Threading.Timer uiTimer;
        public Form1()
        {
            InitializeComponent();

            DirectoryTextBox.Text = LoadDirectoryFromRegistry();

            uiTimer = new System.Threading.Timer(UpdateDataGridView, null, 0, 100);
        }
        private void DirectorySaveButton_Click(object sender, EventArgs e)
        {
            SaveDirectoryToRegistry(DirectoryTextBox.Text);
        }
        public void SaveDirectoryToRegistry(string directoryPath)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\MyFileExplorer");
            if (key != null)
            {
                key.SetValue("LastDirectory", directoryPath);
                key.Close();
            }
        }
        public string LoadDirectoryFromRegistry()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\MyFileExplorer");
            if (key != null)
            {
                object val = key.GetValue("LastDirectory");
                if (val != null)
                {
                    return val.ToString();
                }
            }
            return string.Empty;
        }
        private void GenerateDataButton_Click(object sender, EventArgs e)
        {
            GenerateData.GenerateAndSaveProducts();
        }
        private void LoadFilesButton_Click(object sender, EventArgs e)
        {
            string directoryPath = DirectoryTextBox.Text;

            if (!Directory.Exists(directoryPath))
            {
                MessageBox.Show("Указанная директория не существует.");
                return;
            }

            FilesDataGridView.Invoke(new Action(() => FilesDataGridView.Rows.Clear()));
            fileQueue = new ConcurrentQueue<FileInfo>();

            ThreadPool.QueueUserWorkItem(_ => SearchFiles(directoryPath));
        }
        private void SearchFiles(string directory)
        {
            try
            {
                semaphore.Wait();

                foreach (var file in Directory.GetFiles(directory))
                {
                    if (Path.GetExtension(file).Equals(".dll", StringComparison.OrdinalIgnoreCase))
                        continue;
                    else if (Path.GetExtension(file).Equals(".tmp", StringComparison.OrdinalIgnoreCase))
                        continue;
                    else if (Path.GetExtension(file).Equals(".ini", StringComparison.OrdinalIgnoreCase))
                        continue;
                    else if (Path.GetExtension(file).Equals(".fon", StringComparison.OrdinalIgnoreCase))
                        continue;
                    else if (Path.GetExtension(file).Equals(".ttf", StringComparison.OrdinalIgnoreCase))
                        continue;
                    else if (Path.GetExtension(file).Equals(".ttc", StringComparison.OrdinalIgnoreCase))
                        continue;

                    fileQueue.Enqueue(new FileInfo(file));
                }

                foreach (var subDir in Directory.GetDirectories(directory))
                {
                    ThreadPool.QueueUserWorkItem(_ => SearchFiles(subDir));
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                semaphore.Release();
            }
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
