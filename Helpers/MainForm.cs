using FileExplorer.Config;
using Microsoft.Win32;

namespace FileExplorer.Helpers
{
    public static class MainForm
    {
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
