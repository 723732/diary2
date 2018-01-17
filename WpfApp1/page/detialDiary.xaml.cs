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
    /// detialDiary.xaml 的交互逻辑
    /// </summary>
    public partial class detialDiary : Page
    {
        //public detialDiary()
        //{
        //    InitializeComponent();
        //    _detialDiaryModel = new detilDiaryModel();
        //    this.DataContext = _detialDiaryModel;
        //    _detialDiaryModel.show();
        //}
        
        public detialDiary(string tittle,string date,string content)
        {
            InitializeComponent();
            _detialDiaryModel = new detilDiaryModel();
            this.DataContext = _detialDiaryModel;

            _detialDiaryModel.tittle = tittle;
            _detialDiaryModel.date = date;
            _detialDiaryModel.content = content;
        }
        private detilDiaryModel _detialDiaryModel;

        private void ExchangeData_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _detialDiaryModel.ExchangeData();
        }

        private void ExchangeData_CanExcute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
