using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpuUsageReaderApp
{
    static class Program
    {
        static Timer _timer;
        static NotifyIcon _icon;
        static ImageCreator _creator;
        static PerformanceCounter _cpu;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Process p = Process.GetCurrentProcess())
                p.PriorityClass = ProcessPriorityClass.BelowNormal;

            _cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _creator = new ImageCreator();
            _icon = new NotifyIcon()
            {
                Icon = _creator.GetIcon(0),
                Visible = true
            };

            _timer = new Timer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = 1000;
            _timer.Start();

            Application.ApplicationExit += Application_ApplicationExit;
            Application.ThreadException += Application_ThreadException;
            Application.Run(new AboutForm());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), "Unhandled exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            try
            {
                //try to dispose objects...
                Shutdown();
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.ToString(), "Unhandled exception in shutdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            throw e.Exception;
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Shutdown();
        }

        private static void Shutdown()
        {
            _icon.Visible = false;

            _timer.Tick -= Timer_Tick;
            _timer.Stop();
            _timer.Dispose();
            _icon.Dispose();
            _creator.Dispose();
            _cpu.Dispose();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            _icon.Icon = _creator.GetIcon((int)_cpu.NextValue());
        }   
    }
}
