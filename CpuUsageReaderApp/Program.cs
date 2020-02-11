using System;
using System.Collections.Generic;
using System.Configuration;
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
        static Icons _creator;
        static PerformanceCounter _cpu;
        static AboutForm _form;
        static ContextMenu _menu;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string interval = ConfigurationManager.AppSettings.Get("Interval");
            string priority = ConfigurationManager.AppSettings.Get("Priority");
            string font = ConfigurationManager.AppSettings.Get("Font");
            string fontsize = ConfigurationManager.AppSettings.Get("FontSize");
            string fontstyle = ConfigurationManager.AppSettings.Get("FontStyle");
            string background = ConfigurationManager.AppSettings.Get("BackgroundColor");
            string foreground = ConfigurationManager.AppSettings.Get("ForegroundColor");

            ProcessPriorityClass priorityClass = (ProcessPriorityClass)Enum.Parse(typeof(ProcessPriorityClass), priority);

            using (Process p = Process.GetCurrentProcess())
                p.PriorityClass = priorityClass;

            _cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _creator = new Icons(font, int.Parse(fontsize), fontstyle, background, foreground);
            _icon = new NotifyIcon()
            {
                Icon = _creator.GetIcon(0),
                Visible = true,
                Text = "CPU Usage Reader App"
            };
            _icon.DoubleClick += Icon_DoubleClick;

            _menu = new ContextMenu();
            _menu.MenuItems.Add("About", Icon_About);
            _menu.MenuItems.Add("Exit", Icon_Exit);
            
            _icon.ContextMenu = _menu;

            _timer = new Timer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = int.Parse(interval);
            _timer.Start();

            _form = new AboutForm(priorityClass, _timer.Interval);

            Application.ApplicationExit += Application_ApplicationExit;
            Application.ThreadException += Application_ThreadException;
            Application.Run();
        }

        private static void Icon_About(object sender, EventArgs e)
        {
            _form.Show();
        }

        private static void Icon_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static void Icon_DoubleClick(object sender, EventArgs e)
        {
            _form.Show();
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
            _form.Close();
            _timer.Stop();

            _timer.Dispose();
            _icon.Dispose();
            _menu.Dispose();
            _creator.Dispose();
            _cpu.Dispose();
            _form.Dispose();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            _icon.Icon = _creator.GetIcon((int)_cpu.NextValue()); 
        }   
    }
}
