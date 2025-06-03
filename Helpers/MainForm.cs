using FileExplorer.Config;
using Microsoft.Win32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FileExplorer.Helpers
{
    public static class MainForm
    {
        public static void SearchFiles(string directory, ConcurrentQueue<FileInfo> fileQueue, SemaphoreSlim semaphore, string extension)
        {
            IEnumerable<string> files;
            semaphore.Wait();
            try
            {

                if (!string.IsNullOrEmpty(extension))
                    files = Directory.GetFiles(directory).Where(d => Path.GetExtension(d).Equals(extension));
                else
                    files = Directory.GetFiles(directory);

                foreach (var file in files)
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
                    ThreadPool.QueueUserWorkItem(_ => SearchFiles(subDir, fileQueue, semaphore, extension));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                semaphore.Release();
            }
        }
        public static void SaveDirectoryToRegistry(string directoryPath)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(Strings.RegeditKey);
            if (key != null)
            {
                key.SetValue(Strings.RegeditKeyName, directoryPath);
                key.Close();
            }
        }
        public static string LoadDirectoryFromRegistry()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(Strings.RegeditKey);
            if (key != null)
            {
                object val = key.GetValue(Strings.RegeditKeyName);
                if (val != null)
                {
                    return val.ToString();
                }
            }
            return string.Empty;
        }
    }
}