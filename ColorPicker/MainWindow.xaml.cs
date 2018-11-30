using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorPicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum UserState
        {
            Nominal,
            Selecting
        }

        private UserState currentState = UserState.Nominal;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void colorChanged(Color color)
        {
            var redDec = color.R.ToString();
            var redHex = string.Format("{0:X}", color.R);
            var greenDec = color.G.ToString();
            var greenHex = string.Format("{0:X}", color.G);
            var blueDec = color.B.ToString();
            var blueHex = string.Format("{0:X}", color.B);
            txtBxHex.Text = $"#{redHex}{greenHex}{blueHex}";
            txtBxRed.Text = redDec;
            txtBxGreen.Text = greenDec;
            txtBxBlue.Text = blueDec;
            canvasExample.Background = new SolidColorBrush(color);
        }

        private Color SamplePixelForColor()
        {
            // Retrieve the coordinate of the mouse position in relation to the supplied image.
            Point point = Mouse.GetPosition(ColorWheel);

            // Use RenderTargetBitmap to get the visual, in case the image has been transformed.
            var renderTargetBitmap = new RenderTargetBitmap((int)ColorWheel.ActualWidth,
                                                            (int)ColorWheel.ActualHeight,
                                                            96, 96, PixelFormats.Default);
            renderTargetBitmap.Render(ColorWheel);

            // Make sure that the point is within the dimensions of the image.
            if ((point.X <= renderTargetBitmap.PixelWidth) && (point.Y <= renderTargetBitmap.PixelHeight))
            {
                // Create a cropped image at the supplied point coordinates.
                var croppedBitmap = new CroppedBitmap(renderTargetBitmap,
                                                      new Int32Rect((int)point.X, (int)point.Y, 1, 1));

                // Copy the sampled pixel to a byte array.
                var pixels = new byte[4];
                croppedBitmap.CopyPixels(pixels, 4, 0);

                // Assign the sampled color to a SolidColorBrush and return as conversion.
                 return Color.FromArgb(255, pixels[2], pixels[1], pixels[0]);
            }
            return Color.FromArgb(255, 0, 0, 0);
        }
        
        private void ColorWheel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentState = UserState.Selecting;
            var color = SamplePixelForColor();
            colorChanged(color);
        }

        private void ColorWheel_MouseMove(object sender, MouseEventArgs e)
        {
            if(currentState == UserState.Selecting)
            {
                var color = SamplePixelForColor();

                colorChanged(color);
            }
        }

        private void ColorWheel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            currentState = UserState.Nominal;
        }
    }
}
