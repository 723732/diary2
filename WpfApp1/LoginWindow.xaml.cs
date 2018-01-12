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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            _LoginModel = new LoginModel();
            this.DataContext = _LoginModel;
        }
        private LoginModel _LoginModel;

        private void LoginMainWindow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _LoginModel.LoginMainWindow();
            this.Close();
        }

        private void LoginMainWindow_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
