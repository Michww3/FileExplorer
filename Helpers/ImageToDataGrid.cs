using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FileExplorer.Helpers
{
    public static partial class ImageToDataGrid
    {
        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_SMALLICON = 0x1;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyIcon(IntPtr hIcon);
        public static Icon GetFileIcon(string filePath)
        {
            SHFILEINFO shinfo = new SHFILEINFO();

            IntPtr result = SHGetFileInfo(filePath, 0, ref shinfo,
                (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);

            // Создаём иконку
            Icon icon;
            try
            {
                icon = (Icon)Icon.FromHandle(shinfo.hIcon).Clone();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return SystemIcons.WinLogo;
            }
            finally
            {
                // Освобождаем оригинальный дескриптор
                DestroyIcon(shinfo.hIcon);
            }
            return icon;
        }
        // Импорты для получения иконки
        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes,
            ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
    }
}