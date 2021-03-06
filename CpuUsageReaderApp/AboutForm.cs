﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CpuUsageReaderApp
{
    public partial class AboutForm : Form
    {
        public AboutForm(ProcessPriorityClass priorityClass, int interval)
        {
            InitializeComponent();
            string contents = "Not able to read NOTICE.txt. Please go to project url to see attributions";
            try
            {
                contents = File.ReadAllText("NOTICE.txt");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error reading NOTICE.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBoxNotice.Text = contents;
            textBoxSettings.Text = "Priority = " + priorityClass.ToString() + Environment.NewLine + "Interval (ms) = " + interval;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = true;
            Hide();
        }
    }
}
