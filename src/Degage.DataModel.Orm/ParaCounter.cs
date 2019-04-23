using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Degage.DataModel.Orm
{
    public class ParaCounter
    {
        private Int64 _count = 0;
        /// <summary>
        /// 获取计数并使得计数加1
        /// </summary>
        public Int64 Count
        {
            get
            {
                return Interlocked.Increment(ref _count);
            }
        }
        /// <summary>
        /// 获取计数字符串并使得计数加1
        /// </summary>
        public  String CountString
        {
            get
            {
                return Interlocked.Increment(ref _count).ToString();
            }
        }
    }
    public static class ParaCounter<T> where T : class
    {
        private static Int64 _Count = 0;
        /// <summary>
        /// 获取计数并使得计数加1
        /// </summary>
        public static Int64 Count
        {
            get
            {
                return Interlocked.Increment(ref _Count);
            }
        }
        /// <summary>
        /// 获取计数字符串并使得计数加1
        /// </summary>
        public static String CountString
        {
            get
            {
                return Interlocked.Increment(ref _Count).ToString();
            }
        }
    }
}
