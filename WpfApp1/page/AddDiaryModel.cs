using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.page
{
    class AddDiaryModel: INotifyPropertyChanged
    {
        const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DiaryData;Integrated Security=true;";

        public void AddData()
        {
            DataClassDataContext aDataContext = new DataClassDataContext(ConnectionString);

            Diary aNewDiary = new Diary { Tittle = _Tittle, Content=_Content, Date= DateTime.Now.ToString("G"), Num=LoginModel.UserNum};
            aDataContext.Diary.InsertOnSubmit(aNewDiary);
            aDataContext.SubmitChanges();
        }

        public string Tittle { get { return _Tittle; } set { if (_Tittle == value) return; _Tittle = value; OnPropertyChanged(nameof(Tittle)); } }
        private string _Tittle;

        public string  Content { get { return _Content; } set { if (_Content == value) return; _Content = value; OnPropertyChanged(nameof(Content)); } }
        private string  _Content;

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
