using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace QuickPick.Model
{
    public class ButtonTemplate
    {
        public string BackgroundColor { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public ButtonTemplate(Random r, string color = "", int height = 70,int width = 70)
        {
            Height = height;
            Width = width;
            BackgroundColor = color == "" ? GetRandomColor(r) : color;
        }

        public static string GetRandomColor(Random r)
        {
            return Color.FromArgb((byte)r.Next(0, 256), (byte)r.Next(0, 256), (byte)r.Next(0, 256), (byte)r.Next(0, 256)).ToString();
        }
    }
}
