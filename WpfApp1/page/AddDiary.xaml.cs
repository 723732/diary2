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

namespace WpfApp1.page
{
    /// <summary>
    /// AddDiary.xaml 的交互逻辑
    /// </summary>
    public partial class AddDiary : Page
    {
        public AddDiary()
        {
            InitializeComponent();
            _AddDiaryModel = new AddDiaryModel();
            this.DataContext = _AddDiaryModel;
        }
        private AddDiaryModel _AddDiaryModel;

        private void AddData_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _AddDiaryModel.AddData();
            //AllDiary page = new AllDiary();
            //NavigationService ns = NavigationService.GetNavigationService(this);
            //ns.Navigate(page);
        }

        private void AddData_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
                e.CanExecute = true;
        }
    }
}
