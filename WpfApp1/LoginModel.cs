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
        public static int UserNum;

        public void NewUser()
        {
            try
            {
                // 连接数据库引擎
                using (DataClassDataContext aDataContext = new DataClassDataContext(ConnectionString))
                {
                    if (!aDataContext.DatabaseExists())
                    {
                        aDataContext.CreateDatabase();
                        Console.WriteLine("数据库已经创建！");
                        Number aNewNum = new Number { exNum = 0, nowNum = 1 };
                        aDataContext.Number.InsertOnSubmit(aNewNum);
                        aDataContext.SubmitChanges();
                    }
                    else
                    {
                        Console.WriteLine("数据库已经存在！");
                    }

                    //Console.WriteLine("插入新记录……");
                    //User aNewContact = new User { UserName = "zhang", Num = "1", Password = "111111" };
                    //aDataContext.User.InsertOnSubmit(aNewContact);
                    //aDataContext.SubmitChanges();
                    User aUser = (from r in aDataContext.User where r.UserName == _UserName select r).FirstOrDefault();
                    if (aUser != null)
                    {
                        MessageBox.Show("用户已存在，请重新输入用户名！");
                    }
                    else
                    {
                        Number aNumber = (from r in aDataContext.Number select r).FirstOrDefault();

                        User aNewContact = new User { UserName = _UserName, Password = _Password, Num = aNumber.nowNum };
                        aDataContext.User.InsertOnSubmit(aNewContact);

                        Number aNewNum = new Number { exNum = aNumber.nowNum, nowNum = aNumber.nowNum + 1 };
                        aDataContext.Number.InsertOnSubmit(aNewNum);
                        aDataContext.Number.DeleteOnSubmit(aNumber);

                        aDataContext.SubmitChanges();
                        MessageBox.Show("注册成功，请登陆！");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

            public void LoginMainWindow()
        {
            DataClassDataContext aDataContext = new DataClassDataContext(ConnectionString);

            User aUser = (from r in aDataContext.User where r.UserName == _UserName select r).FirstOrDefault();
            if (aUser != null)
            {
                UserNum = aUser.Num;
                if(aUser.Password == _Password)
                {
                    MainWindow mainWindow = new MainWindow();

                    App.Current.MainWindow = mainWindow;
                    mainWindow.Show();

                   //                Console.WriteLine("插入新记录……");
                  //                 Diary aNewContact = new Diary { Tittle = "张三", Content = "13000000000", Date = "20170202", Num = "2" };
                  //                aDataContext.Diary.InsertOnSubmit(aNewContact);
                 //                 aDataContext.SubmitChanges();
                 //   Console.WriteLine("插入新记录……");
               //                 User aNewContact = new User { UserName = "张三",Password="111111", Num = "2" };
                //                 aDataContext.User.InsertOnSubmit(aNewContact);
               //                   aDataContext.SubmitChanges();
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
