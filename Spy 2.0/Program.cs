using System;
using System.Windows.Forms;
using Spy_2._0.Forms;

namespace Spy_2._0
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
