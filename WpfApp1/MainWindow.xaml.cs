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


namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _filterPage = new page.allDiaryModel();
            this.DataContext = _filterPage;
            
            //添加页面的Uri地址，采用相对路径，根路径是项目名,实现allViews的初始化  
            allViews.Add("page1", new Uri("page/AllDiary.xaml", UriKind.Relative));
            allViews.Add("page2", new Uri("page/AddDiary.xaml", UriKind.Relative));

       //     mainFrame.Navigate(allViews["page1"]);
        }
        private page.allDiaryModel _filterPage;
        private Dictionary<string, Uri> allViews = new Dictionary<string, Uri>(); //包含所有页面 

        private void ShowDia_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        //    _filterPage.ShowData();
            mainFrame.Navigate(allViews["page1"]);
            
        }
        
        private void ShowDia_CanEecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddDia_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mainFrame.Navigate(allViews["page2"]);
        }

        private void AddDia_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void StartFilter_Executed(object sender, ExecutedRoutedEventArgs e)
        {
      //      _filterPage.DoFilter();
            mainFrame.Navigate(allViews["page1"]);
        }

        private void StartFilter_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
