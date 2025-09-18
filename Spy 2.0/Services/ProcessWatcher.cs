using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using Spy_2._0.Models;

namespace Spy_2._0.Services
{
    public class ProcessWatcher
    {
        private readonly AppSettings _settings;
        private ManagementEventWatcher _watcher;

        public ProcessWatcher(AppSettings settings)
        {
            _settings = settings;
        }

        public void Start()
        {
            try
            {
                string query = "SELECT * FROM Win32_ProcessStartTrace";
                _watcher = new ManagementEventWatcher(new WqlEventQuery(query));
                _watcher.EventArrived += Watcher_EventArrived;
                _watcher.Start();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка ProcessWatcher: " + ex.Message);
            }
        }

        private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string processRaw = e.NewEvent.Properties["ProcessName"].Value.ToString();
            string processName = Path.GetFileNameWithoutExtension(processRaw);
            DateTime startTime = DateTime.Now;

            if (!Directory.Exists(_settings.ReportsPath)) Directory.CreateDirectory(_settings.ReportsPath);
            string filePath = Path.Combine(_settings.ReportsPath, "process_log.txt");
            string logLine = $"{startTime:yyyy-MM-dd HH:mm:ss} - {processRaw}";

            if (_settings.Moderation && _settings.ForbiddenPrograms.Contains(processName, StringComparer.OrdinalIgnoreCase))
            {
                try
                {
                    foreach (var proc in Process.GetProcessesByName(processName))
                        proc.Kill();
                    logLine = $"{startTime:yyyy-MM-dd HH:mm:ss} - BLOCKED {processRaw}";
                }
                catch (Exception ex)
                {
                    logLine = $"{startTime:yyyy-MM-dd HH:mm:ss} - ERROR closing {processRaw}: {ex.Message}";
                }
            }

            File.AppendAllText(filePath, logLine + Environment.NewLine);
        }

        public void Stop()
        {
            _watcher?.Stop();
            _watcher?.Dispose();
        }
    }
}
