using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Spy_2._0.Models
{
    public class AppSettings
    {
        public string ReportsPath { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
        public bool Statistics { get; set; }
        public bool Moderation { get; set; }
        public List<string> ForbiddenWords { get; set; } = new List<string>();
        public List<string> ForbiddenPrograms { get; set; } = new List<string>();

        private static string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

        public void Save()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public static AppSettings Load()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<AppSettings>(json);
            }
            return new AppSettings();
        }

        public void LogKey(string key)
        {
            if (!Directory.Exists(ReportsPath)) Directory.CreateDirectory(ReportsPath);
            string filePath = Path.Combine(ReportsPath, "log.txt");
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {key}";
            File.AppendAllText(filePath, line + Environment.NewLine, Encoding.UTF8);
        }
    }
}
