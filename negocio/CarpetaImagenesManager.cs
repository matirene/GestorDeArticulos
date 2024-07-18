using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class CarpetaImagenesManager
    {
        private static string folderPath;

        private const string configKey = "ImageFolderPath";

        static CarpetaImagenesManager()
        {
            folderPath = ConfigurationManager.AppSettings[configKey];

            if (string.IsNullOrEmpty(folderPath))
                folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "GestorDeArticulos", "Imagenes");
            
            EnsureDirectoryExists(folderPath);
        }

        public static string FolderPath
        {
            get { return folderPath; }

            set 
            {
                EnsureDirectoryExists(folderPath);
                folderPath = value;
                UpdateAppConfig(value);
            }
        }

        public static void changeFolderPath(string path)
        {
            FolderPath = path;
        }

        private static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private static void UpdateAppConfig(string path)
        {
            //Actualiza el App.config
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[configKey].Value = path;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
