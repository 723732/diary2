using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static WpfApp1.page.allDiaryModel;

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
            this.dataGrid.DataContext = _allDiaryModel.mylist;
    //        Console.WriteLine("界面mylist");
     //       Console.WriteLine(_allDiaryModel.mylist.Count);

        }
        private allDiaryModel _allDiaryModel;

        public string Tittle1 { get { return _Tittle1; } set { if (_Tittle1 == value) return; _Tittle1 = value; } }
        private static string _Tittle1;

        public string Date1 { get { return _Date1; } set { if (_Date1 == value) return; _Date1 = value; } }
        private string _Date1;

        public string Content1 { get { return _Content1; } set { if (_Content1 == value) return; _Content1 = value; } }
        private string _Content1;

        private void DetialDiary_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Tittle1 = (this.dataGrid.SelectedItem as DiaryData).Tittle;
            Date1 = (this.dataGrid.SelectedItem as DiaryData).Date;
            Content1 = (this.dataGrid.SelectedItem as DiaryData).Content;
     //       Console.WriteLine(Tittle1);

            detialDiary page = new detialDiary(Tittle1,Date1,Content1);
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }

        private void DetialDiary_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteDiary_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Date1 = (this.dataGrid.SelectedItem as DiaryData).Date;
            _allDiaryModel.DeleteData(Date1);

        }

        private void DeleteDiary_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
