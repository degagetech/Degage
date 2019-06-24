using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.EMS.VersionControl
{
    //您有新的响应消息请定义在此类中
    /// <summary>
    /// 常用服务响应消息的集合
    /// </summary>
    public class ResponseMessages
    {

        public static String InvaildSession { get; } = "会话信息无效！";
        /// <summary>
        /// 操作成功
        /// </summary>
        public  static String SuccessedOperation { get; } = "操作成功";
        /// <summary>
        /// 数据操作失败
        /// </summary>
        public  static String DataOperateFailed { get; } = "数据操作失败";
        /// <summary>
        /// 数据操作异常
        /// </summary>
        public  static String DataOperateException { get; } = "数据操作异常";
        /// <summary>
        /// 参数无效
        /// </summary>
        public  static String InvaildParameter { get; } = "参数无效";
        /// <summary>
        /// 未能找到对应信息
        /// </summary>
        public  static String NotFoundInfos { get; } = "未能找到对应信息";
    }
}
