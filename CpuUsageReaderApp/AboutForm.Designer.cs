namespace CpuUsageReaderApp
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxNotice = new System.Windows.Forms.TextBox();
            this.textBoxSettings = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 99);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(352, 95);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(12, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(352, 81);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "A very simple efficient application that reads from performance counter and displ" +
    "ays the cpu process time in a system tray icon.";
            // 
            // textBoxNotice
            // 
            this.textBoxNotice.Location = new System.Drawing.Point(12, 200);
            this.textBoxNotice.Multiline = true;
            this.textBoxNotice.Name = "textBoxNotice";
            this.textBoxNotice.ReadOnly = true;
            this.textBoxNotice.Size = new System.Drawing.Size(352, 125);
            this.textBoxNotice.TabIndex = 3;
            // 
            // textBoxSettings
            // 
            this.textBoxSettings.Location = new System.Drawing.Point(12, 331);
            this.textBoxSettings.Multiline = true;
            this.textBoxSettings.Name = "textBoxSettings";
            this.textBoxSettings.ReadOnly = true;
            this.textBoxSettings.Size = new System.Drawing.Size(352, 57);
            this.textBoxSettings.TabIndex = 4;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 400);
            this.Controls.Add(this.textBoxSettings);
            this.Controls.Add(this.textBoxNotice);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About - CPU Usage Reader App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBoxNotice;
        private System.Windows.Forms.TextBox textBoxSettings;
    }
}