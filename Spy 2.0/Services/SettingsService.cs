using Newtonsoft.Json;
using Spy_2._0.Models;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Spy_2._0.Services
{
    public static class SettingsService
    {
        private static string FilePath => Path.Combine(Application.StartupPath, "settings.json");

        public static AppSettings Load()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<AppSettings>(json);
            }
            return new AppSettings
            {
                ReportsPath = Path.Combine(Application.StartupPath, "Reports"),
                ForbiddenWords = new List<string>(),
                ForbiddenPrograms = new List<string>()
            };
        }

        public static void Save(AppSettings settings)
        {
            string json = JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
