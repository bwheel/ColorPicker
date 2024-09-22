using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorPalette.Helpers
{
    public static class ColorHelpers
    {
        private static readonly Random rng = new Random(DateTime.UtcNow.Millisecond);
        public static Color GetRandomColor()
            => Color.FromRgb((byte)rng.Next(0, 255), (byte)rng.Next(0, 255), (byte)rng.Next(0, 255));
        public static string ToHex(Color c)
            => $"#{c.R:X2}{c.G:X2}{c.B:X2}";
    }
}
