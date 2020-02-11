using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuUsageReaderApp
{
    public class ImageCreator : IDisposable
    {
        Icon[] _icons;
        public ImageCreator()
        {
            _icons = new Icon[100];
            for(int i = 0; i < _icons.Length; i++)
            {
                _icons[i] = CreateIcon((i + 1).ToString());
            }
        }
        public Icon GetIcon(int number)
        {
            number -= 1;
            if(number > 0 && number < _icons.Length)
            {
                return _icons[number];
            }
            return _icons[0];
        }

        static Icon CreateIcon(string number)
        {
            using (Font font = new Font("Consolas", 21, FontStyle.Bold))
            using (Image img = new Bitmap(32, 32))
            using (Graphics graphics = Graphics.FromImage(img))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                float x;
                if (number.Length > 1)
                {
                    x = -4;
                }
                else
                {
                    x = 2;
                }

                graphics.Clear(Color.White);
                graphics.DrawString(number, font, brush, x, 0);
                graphics.Save();
                return Icon.FromHandle((img as Bitmap).GetHicon()) as Icon;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach(var icon in _icons)
                    {
                        icon?.Dispose();
                    }
                    _icons = null;
                }

                disposedValue = true;
            }
        }

        ~ImageCreator()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
