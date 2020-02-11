using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpuUsageReaderApp
{
    public partial class AboutForm : Form
    {
        public AboutForm()
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
        }
    }
}
