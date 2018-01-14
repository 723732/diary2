using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.page
{
    class detilDiaryModel : INotifyPropertyChanged
    {
        const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DiaryData;Integrated Security=true;";

        public void ExchangeData()
        {
            DataClassDataContext aDataContext = new DataClassDataContext(ConnectionString);
            Diary aOtherDiary = (from r in aDataContext.Diary where r.Date == AllDiary.date1 && r.Num==LoginModel.UserNum select r).FirstOrDefault();

            //           aOtherDiary.Tittle = _tittle;
            //           aOtherDiary.Date = DateTime.Now.ToString("G");
            //          aOtherDiary.Content = _content;
            aDataContext.Diary.DeleteOnSubmit(aOtherDiary);
            Diary aNewDiary = new Diary { Tittle = _tittle, Content = _content, Date = DateTime.Now.ToString("G"), Num = LoginModel.UserNum };
            aDataContext.Diary.InsertOnSubmit(aNewDiary);

            aDataContext.SubmitChanges();

            MessageBox.Show("修改成功！");
        }

        public void show()
        {
            _tittle = AllDiary.tittle1;
            _date = AllDiary.date1;
            _content = AllDiary.content1;
           
         //   Console.WriteLine($"{AllDiary.tittle1}");
        }

        public string tittle { get { return _tittle; } set { if (_tittle == value) return; _tittle = value; OnPropertyChanged(nameof(tittle)); } }
        private string _tittle;

        public string date { get { return _date; } set { if (_date == value) return; _date = value; OnPropertyChanged(nameof(date)); } }
        private string _date;

        public string content { get { return _content; } set { if (_content == value) return; _content = value; OnPropertyChanged(nameof(content)); } }
        private string _content;

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
