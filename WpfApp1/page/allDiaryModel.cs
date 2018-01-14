using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.page
{
    class allDiaryModel
    {
        const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DiaryData;Integrated Security=true;";

        public ObservableCollection<allDiaryModel> memberData = new ObservableCollection<allDiaryModel>();
        public void ShowData()
        {
            DataClassDataContext aDataContext = new DataClassDataContext(ConnectionString);

            var aDiarys = from r in aDataContext.Diary where r.Num == LoginModel.UserNum select r;
            foreach (Diary aDiary in aDiarys)
            {
                memberData.Add(new allDiaryModel()
                {
                    _Date = aDiary.Date,
                    _Tittle = aDiary.Tittle,
                    _Content = aDiary.Content
                });
               
            }
        }

        public string Date { get { return _Date; } set { if (_Date == value) return; _Date = value; } }
        private string _Date;

        public string Tittle { get { return _Tittle; } set { if (_Tittle == value) return; _Tittle = value;  } }
        private string _Tittle;

        public string Content { get { return _Content; } set { if (_Content == value) return; _Content = value; } }
        private string _Content;
   
    }
}
