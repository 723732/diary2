using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.page
{
    class AddDiaryModel: INotifyPropertyChanged
    {
        const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DiaryData;Integrated Security=true;";

        public void AddData()
        {
            DataClassDataContext aDataContext = new DataClassDataContext(ConnectionString);

            if(Date == null)
            {
                Date = DateTime.Now.ToString("G");
                Diary aNewDiary = new Diary { Tittle = _Tittle, Content = _Content, Date = Date, Num = LoginModel.UserNum };
                aDataContext.Diary.InsertOnSubmit(aNewDiary);
                aDataContext.SubmitChanges();

                MessageBox.Show("提交成功！");
            }
            else
            {
                Diary aOtherDiary = (from r in aDataContext.Diary where r.Date == Date && r.Num == LoginModel.UserNum select r).FirstOrDefault();
                aDataContext.Diary.DeleteOnSubmit(aOtherDiary);
                Date = DateTime.Now.ToString("G");
                Diary aNewDiary = new Diary { Tittle = _Tittle, Content = _Content, Date = Date, Num = LoginModel.UserNum };
                aDataContext.Diary.InsertOnSubmit(aNewDiary);

                aDataContext.SubmitChanges();

                MessageBox.Show("提交成功！");
            }
        }

        public string Tittle { get { return _Tittle; } set { if (_Tittle == value) return; _Tittle = value; OnPropertyChanged(nameof(Tittle)); } }
        private string _Tittle;

        public string  Content { get { return _Content; } set { if (_Content == value) return; _Content = value; OnPropertyChanged(nameof(Content)); } }
        private string  _Content;

        public string Date { get { return _Date; } set { if (_Date == value) return; _Date = value; OnPropertyChanged(nameof(Date)); } }
        private string _Date;

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
