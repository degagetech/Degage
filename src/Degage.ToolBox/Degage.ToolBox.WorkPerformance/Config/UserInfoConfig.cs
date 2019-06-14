using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPerformance
{
    public class UserInfoConfig : Config
    {
        public UserInfoConfig()
        {
        }
        public String EmailAddress { get; set; }
        public String Password { get; set; }
        public String DefaultReceviceEmail { get; set; }
        public String Name { get; set; }
        public String Department { get; set; }

        public String GetDefaultPerformanceTile()
        {
            DateTime time = DateTime.Now;
            String timeStr = time.ToString("yyyyMM");
            String name = this.Name ?? "#";
            String department = this.Department ?? "#";
            //月度绩效考核表-201903-医技技术-王浪静 

            String title = $"月度绩效考核表_{timeStr}_{department}_{name}";
            return title;
        }
        /// <summary>
        /// 当前的用户信息配置是否有效
        /// </summary>
        /// <returns></returns>
        public Boolean IsVaild()
        {
            Boolean vaild = true;
            if (String.IsNullOrWhiteSpace(this.EmailAddress))
            {
                vaild = false;
            }

            if (String.IsNullOrWhiteSpace(this.Password))
            {
                vaild = false;
            }
            return vaild;
        }
        public override void OnLoaded()
        {
        }
    }
}
