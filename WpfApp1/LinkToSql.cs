using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class LinkToSql
    {
        const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DiaryData;Integrated Security=true;";
        public void LinkSql()
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
                    }
                    else
                    {
                        Console.WriteLine("数据库已经存在！");
                    }

                    Console.WriteLine("插入新记录……");
                    User aNewContact = new User {UserName="zhang",Num="1",Password="111111"};
                    aDataContext.User.InsertOnSubmit(aNewContact);
                    aDataContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            //       Console.WriteLine("按回车键退出……");
            //     Console.ReadLine();

        }
    }
}
