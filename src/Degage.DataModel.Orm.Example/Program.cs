using System;

namespace Degage.DataModel.Orm.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! degage data model orm.");
            //var connStr = "server= ip ;Port= port ;Uid= root ;Pwd= password ;DataBase= dbname ;Pooling=true;charset=utf8;";
            var connStr = "server= degage.me ;Port= 3306 ;Uid= root ;Pwd= 932444208wlj- ;DataBase= test ;Pooling=true;charset=utf8;";

            //以下示例需要您在事先 Mariadb 中执行 test_user.sql 脚本以创建结构信息
            //The following example requires you to execute the test_user.sql script in Mariadb in advance to create structural information

            MySqlDbProvider proivder = new MySqlDbProvider("MySQL", connStr);

            //获取用户信息
            //get user infos
            var userInfos = proivder.Select<TestUser>().ToList();
            //show
            foreach (var info in userInfos)
            {
                Console.WriteLine($"Id:{info.Id}, Name:{info.Name} , Age:{info.Age}, Born:{info.Born.ToString("yyyy-MM-dd")}, Desc:{info.Descrption}");
            }

        }
        public class TestUser
        {
            public String Id { get; set; }
            public String Name { get; set; }
            public Int32 Age { get; set; }
            public DateTime Born { get; set; }
            public String Descrption { get; set; }
        }
    }
}
