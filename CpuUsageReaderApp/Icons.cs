using System;
using System.Drawing;
using System.Threading.Tasks;

namespace CpuUsageReaderApp
{
    public class Icons : IDisposable
    {
        Icon[] _icons;
        public Icons(string font, int fontsize, string fontstyle, string background, string foreground, int xpos1, int xpos2)
        {
            _icons = new Icon[101];
            Parallel.For(0, _icons.Length, (i) =>
            {
                //Safe to do multithreading because other threads are not stepping up on each other
                _icons[i] = CreateIcon((i).ToString(), font, fontsize, fontstyle, background, foreground, xpos1, xpos2);
            });
        }
        public Icon GetIcon(int number)
        {
            if(number >= 0 && number <= _icons.Length)
            {
                return _icons[number];
            }
            return _icons[0];
        }

        static Icon CreateIcon(string number, string fontStr, int fontsize, string fontstyle, string backgroundStr, string foregroundStr, int xpos1, int xpos2)
        {
            FontStyle style = (FontStyle)Enum.Parse(typeof(FontStyle), fontstyle);
            Color background;
            if (backgroundStr.Equals("Transparent", StringComparison.OrdinalIgnoreCase))
            {
                background = Color.FromArgb(0, 0, 0, 0);
            }
            else
            {
                background = ColorTranslator.FromHtml(backgroundStr);
            }
            
            Color foreground = ColorTranslator.FromHtml(foregroundStr);
            
            using (Font font = new Font(fontStr, fontsize, style))
            using (Image img = new Bitmap(32, 32))
            using (Graphics graphics = Graphics.FromImage(img))
            using (Brush brush = new SolidBrush(foreground))
            {
                float x;
                if (number.Length > 1)
                {
                    x = xpos2;
                }
                else
                {
                    x = xpos1;
                }

                graphics.Clear(background);
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

        ~Icons()
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
