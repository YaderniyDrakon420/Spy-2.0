using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Windows.Forms;
using Spy_2._0.Models;

namespace Spy_2._0.Services
{
    public class ProcessWatcher
    {
        private ManagementEventWatcher _watcher;
        private readonly AppSettings _settings;

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
                _watcher.EventArrived += ProcessStarted;
                _watcher.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка запуска ProcessWatcher: " + ex.Message);
            }
        }

        public void Stop()
        {
            _watcher?.Stop();
            _watcher?.Dispose();
        }

        private void ProcessStarted(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            DateTime startTime = DateTime.Now;

            string path = _settings.ReportsPath;
            if (string.IsNullOrWhiteSpace(path))
                path = Path.Combine(Application.StartupPath, "Reports");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filePath = Path.Combine(path, "process_log.txt");

            if (_settings.Moderation && _settings.ForbiddenPrograms != null)
            {
                if (_settings.ForbiddenPrograms.Contains(processName, StringComparer.OrdinalIgnoreCase))
                {
                    try
                    {
                        foreach (var proc in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processName)))
                            proc.Kill();

                        File.AppendAllText(filePath,
                            $"{startTime:yyyy-MM-dd HH:mm:ss} - BLOCKED {processName}{Environment.NewLine}");
                        return;
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(filePath,
                            $"{startTime:yyyy-MM-dd HH:mm:ss} - ERROR closing {processName}: {ex.Message}{Environment.NewLine}");
                        return;
                    }
                }
            }

            File.AppendAllText(filePath,
                $"{startTime:yyyy-MM-dd HH:mm:ss} - {processName}{Environment.NewLine}");
        }
    }
}
