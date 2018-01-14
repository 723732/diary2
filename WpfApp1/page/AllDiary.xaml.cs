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
    /// AllDiary.xaml 的交互逻辑
    /// </summary>
    public partial class AllDiary : Page
    {
        public AllDiary()
        {
            InitializeComponent();
            _allDiaryModel = new allDiaryModel();
            dataGrid.DataContext = _allDiaryModel.memberData;
            _allDiaryModel.ShowData();
        }
        private allDiaryModel _allDiaryModel;
        public static string tittle1;
        public static string date1;
        public static string content1;

        private void DetialDiary_Executed(object sender, ExecutedRoutedEventArgs e)
        {
      //      Console.WriteLine($"{(this.dataGrid.SelectedItem as allDiaryModel).Tittle}");
            //     NavigationService.Navigate(detialDiary, dataGrid);
            tittle1 = (this.dataGrid.SelectedItem as allDiaryModel).Tittle;
            date1 = (this.dataGrid.SelectedItem as allDiaryModel).Date;
            content1 = (this.dataGrid.SelectedItem as allDiaryModel).Content;

            detialDiary page = new detialDiary();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }

        private void DetialDiary_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
