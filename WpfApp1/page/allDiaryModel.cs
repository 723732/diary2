using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.page
{
    class allDiaryModel : INotifyPropertyChanged
    {
        const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DiaryData;Integrated Security=true;";
        //    public List<allDiaryModel> mylist = new List<allDiaryModel>();
        private List<DiaryData> _mylist = new List<DiaryData>();
        public List<DiaryData> mylist
        {

            get { return _mylist; }
            set
            {
                if (_mylist == value) return; _mylist = value;
            }
        }

        public void ShowData()
        {
    //        List<DiaryData> aMylist = new List<DiaryData>();

            DataClassDataContext aDataContext = new DataClassDataContext(ConnectionString);

            var aDiarys = from r in aDataContext.Diary where r.Num == LoginModel.UserNum select r;
            foreach (Diary aDiary in aDiarys)
            {
                mylist.Add(new DiaryData()
                {
                    Date = aDiary.Date,
                    Tittle = aDiary.Tittle,
                    Content = aDiary.Content
                });
            }
            //foreach (Diary aDiary in aDiarys)
            //{
            //    mylist.Add(new allDiaryModel()
            //    {
            //        Date = aDiary.Date,
            //        Tittle = aDiary.Tittle,
            //        Content = aDiary.Content
            //    });
            //}
            //    mylist = aMylist;
            Console.WriteLine(mylist.Count);
        }

        public void DeleteData()
        {
            DataClassDataContext aDataContext = new DataClassDataContext(ConnectionString);
            Diary aOtherDiary = (from r in aDataContext.Diary where r.Date == AllDiary.date1 && r.Num == LoginModel.UserNum select r).FirstOrDefault();
            aDataContext.Diary.DeleteOnSubmit(aOtherDiary);

            aDataContext.SubmitChanges();

            MessageBox.Show("删除成功！");
        }

        public void DoFilter()
        {
            Regex aRegex = new Regex(Pattern);
            Console.WriteLine(Pattern);

            DataClassDataContext aDataContext = new DataClassDataContext(ConnectionString);

            var aDiarys = from r in aDataContext.Diary where r.Num == LoginModel.UserNum select r;
            foreach (Diary aDiary in aDiarys)
            {
                if (aRegex.IsMatch(aDiary.Tittle) || aRegex.IsMatch(aDiary.Content))
                {
                    Console.WriteLine(aDiary.Content);
                    mylist.Add(new DiaryData()
                    {
                        Date = aDiary.Date,
                        Tittle = aDiary.Tittle,
                        Content = aDiary.Content
                    });
                }
            }

        }

        public class DiaryData
        {
            public string Date { get; set; }
            public string Tittle { get; set; }
            public string Content { get; set; }
        }

        //public string Date { get { return _Date; } set { if (_Date == value) return; _Date = value; } }
        //private string _Date;

        //public string Tittle { get { return _Tittle; } set { if (_Tittle == value) return; _Tittle = value;  } }
        //private string _Tittle;

        //public string Content { get { return _Content; } set { if (_Content == value) return; _Content = value; } }
        //private string _Content;

        public string Pattern { get { return _Pattern; } set { if (_Pattern == value) return; _Pattern = value; OnPropertyChanged(nameof(Pattern)); } }
        private string _Pattern;

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
