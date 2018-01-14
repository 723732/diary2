using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    class LoginModel : INotifyPropertyChanged
    {
        const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DiaryData;Integrated Security=true;";
        public static string UserNum;

        public void LoginMainWindow()
        {
            DataClassDataContext aDataContext = new DataClassDataContext(ConnectionString);

            User aUser = (from r in aDataContext.User where r.UserName == UserName select r).FirstOrDefault();
            if (aUser != null)
            {
                UserNum = aUser.Num;
                if(aUser.Password == Password)
                {
                    MainWindow mainWindow = new MainWindow();

                    App.Current.MainWindow = mainWindow;
                    mainWindow.Show();

     //               Console.WriteLine("插入新记录……");
     //               Diary aNewContact = new Diary { Tittle = "张三", Content = "13000000000", Date = "20170202", Num = "2" };
      //              aDataContext.Diary.InsertOnSubmit(aNewContact);
      //              aDataContext.SubmitChanges();
                }
                else
                {
                    MessageBox.Show("密码错误！");
                }
            }
            else
            {
                MessageBox.Show("无此用户！");
            }
        }
        //   private LinkToSql _linkToSql;

        public string  UserName { get { return _UserName; } set { if (_UserName == value) return; _UserName = value; OnPropertyChanged(nameof(UserName)); } }
        private string  _UserName;

        public string  Password { get { return _Password; } set { if (_Password == value) return; _Password = value; OnPropertyChanged(nameof(Password)); } }
        private string  _Password;

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
