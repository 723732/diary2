using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class MainModel : INotifyPropertyChanged
    {
        public string Pattern { get { return _Pattern; } set { if (_Pattern == value) return; _Pattern = value; OnPropertyChanged(nameof(Pattern)); } }
        private string _Pattern;

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
