using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Degage.Extension;
namespace Degage.EMS.VersionControl
{
    /// <summary>
    /// 用户创建各种系统使用的唯一标识信息
    /// </summary>
    public class IdentifyFactory : IDisposable
    {
        public IdentifyFactory()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String CreateId()
        {
            return Guid.NewGuid().ToString("N");
        }

     
        public void Dispose()
        {
     
        }
    }
}
