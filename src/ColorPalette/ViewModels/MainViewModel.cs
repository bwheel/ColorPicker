using ColorPalette.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorPalette.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string[] hexStrings = new string[9];
        private SolidColorBrush[] brushes = new SolidColorBrush[9];
        public MainViewModel()
        {
            for (int i = 0; i < 9; i++)
            {
                var color = ColorHelpers.GetRandomColor();
                hexStrings[i] = ColorHelpers.ToHex(color);
                brushes[i] = new SolidColorBrush(color);
            }
        }
        public string Hex1
        {
            get
            {
                return hexStrings[0];
            }
            set
            {
                hexStrings[0] = value;
                OnPropertyChanged(nameof(Hex1));
            }
        }

        public string Hex2
        {
            get
            {
                return hexStrings[1];
            }
            set
            {
                hexStrings[1] = value;
                OnPropertyChanged(nameof(Hex2));
            }
        }

        public string Hex3
        {
            get
            {
                return hexStrings[2];
            }
            set
            {
                hexStrings[2] = value;
                OnPropertyChanged(nameof(Hex3));
            }
        }

        public string Hex4
        {
            get
            {
                return hexStrings[3];
            }
            set
            {
                hexStrings[3] = value;
                OnPropertyChanged(nameof(Hex4));
            }
        }

        public string Hex5
        {
            get
            {
                return hexStrings[4];
            }
            set
            {
                hexStrings[4] = value;
                OnPropertyChanged(nameof(Hex5));
            }
        }

        public string Hex6
        {
            get
            {
                return hexStrings[5];
            }
            set
            {
                hexStrings[5] = value;
                OnPropertyChanged(nameof(Hex6));
            }
        }

        public SolidColorBrush Background1
        {
            get
            {
                return brushes[0];
            }
            set
            {
                brushes[0] = value;
                OnPropertyChanged(nameof(Background1));
            }
        }

        public SolidColorBrush Background2
        {
            get
            {
                return brushes[1];
            }
            set
            {
                brushes[1] = value;
                OnPropertyChanged(nameof(Background2));
            }
        }

        public SolidColorBrush Background3
        {
            get
            {
                return brushes[2];
            }
            set
            {
                brushes[2] = value;
                OnPropertyChanged(nameof(Background3));
            }
        }

        public SolidColorBrush Background4
        {
            get
            {
                return brushes[3];
            }
            set
            {
                brushes[3] = value;
                OnPropertyChanged(nameof(Background4));
            }
        }

        public SolidColorBrush Background5
        {
            get
            {
                return brushes[4];
            }
            set
            {
                brushes[4] = value;
                OnPropertyChanged(nameof(Background5));
            }
        }

        public SolidColorBrush Background6
        {
            get
            {
                return brushes[5];
            }
            set
            {
                brushes[5] = value;
                OnPropertyChanged(nameof(Background6));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
