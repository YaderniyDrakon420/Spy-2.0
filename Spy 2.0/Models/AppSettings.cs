using System.Collections.Generic;

namespace Spy_2._0.Models
{
    public class AppSettings
    {
        public string ReportsPath { get; set; }
        public bool Statistics { get; set; }
        public bool Moderation { get; set; }
        public List<string> ForbiddenWords { get; set; }
        public List<string> ForbiddenPrograms { get; set; }
    }
}
