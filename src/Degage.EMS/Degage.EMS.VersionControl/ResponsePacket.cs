using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.EMS.VersionControl
{
    /// <summary>
    /// 封装多个常用字段以便于返回响应信息
    /// </summary>
    public class ResponsePacket
    {
        /// <summary>
        /// 表示此次请求处理是否成功
        /// </summary>
        public Boolean Success { get; set; }
        /// <summary>
        /// 响应状态，默认 <see cref="ResponseStatusCodes.OK"/>
        /// </summary>
        public Int32 State { get; set; } = ResponseStatusCodes.OK;
        /// <summary>
        /// 响应附加的消息，通常用于说明处理结果
        /// </summary>
        public String Message { get; set; }

        public static implicit operator ResponsePacket((Boolean success, String message) source)
        {
            return ResponsePacket.From(source);
        }


        /// <summary>
        /// 将对象序列化为 JSON 格式的字符串，此序列化操作只针对于 Public 字段
        /// </summary>
        /// <returns></returns>
        public String ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// 使用指定的参数创建响应包
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponsePacket Create(Boolean success = false, String message = null)
        {
            return new ResponsePacket
            {
                Success = success,
                Message = message
            };
        }

        public static ResponsePacket Create(Boolean success, Int32 state, String message = null)
        {
            return new ResponsePacket
            {
                Success = success,
                State = state,
                Message = message
            };
        }

        /// <summary>
        /// 从特定元组创建响应包
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ResponsePacket From((Boolean success, String message) source)
        {
            return new ResponsePacket
            {
                Success = source.success,
                Message = source.message
            };
        }


        /// <summary>
        /// 使用指定的参数创建包含一个数据对象响应包
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResponsePacket<T> Create<T>(Boolean success, String message, T data)
        {
            return new ResponsePacket<T>
            {
                Success = success,
                Message = message,
                Data = data
            };
        }

        /// <summary>
        /// 从特定元组创建包含一个数据对象的响应包
        /// </summary>
        public static ResponsePacket<T> From<T>((Boolean success, String message, T data) source)
        {
            return new ResponsePacket<T>
            {
                Success = source.success,
                Message = source.message,
                Data = source.data
            };
        }



        /// <summary>
        /// 使用指定的参数创建包含两个数据对象响应包
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <param name="data1"></param>
        /// <returns></returns>
        public static ResponsePacket<T1, T2> Create<T1, T2>(Boolean success, String message, T1 data, T2 data1)
        {
            return new ResponsePacket<T1, T2>
            {
                Success = success,
                Message = message,
                Data = data,
                Data1 = data1
            };
        }


        /// <summary>
        /// 从特定元组创建包含两个数据对象的响应包
        /// </summary>
        public static ResponsePacket<T1, T2> From<T1, T2>((Boolean success, String message, T1 data, T2 data1) source)
        {
            return new ResponsePacket<T1, T2>
            {
                Success = source.success,
                Message = source.message,
                Data = source.data,
                Data1 = source.data1
            };
        }
    }

    /// <summary>
    /// 表示包含一个数据对象的响应包
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponsePacket<T> : ResponsePacket
    {
        /// <summary>
        /// 响应包含的数据对象
        /// </summary>
        public T Data { get; set; }

        public static implicit operator ResponsePacket<T>((Boolean success, String message, T data) source)
        {
            return ResponsePacket.From(source);
        }
    }
    /// <summary>
    /// 表示包含两个数据对象的响应包
    /// </summary>
    public class ResponsePacket<T, T1> : ResponsePacket<T>
    {
        /// <summary>
        /// 响应包含的数据对象1
        /// </summary>
        public T1 Data1 { get; set; }

        public static implicit operator ResponsePacket<T, T1>((Boolean success, String message, T data, T1 data1) source)
        {
            return ResponsePacket.From(source);
        }
    }

    public static class PageModelExtesion
    {
        /// <summary>
        ///  通过指定的 <see cref="ResponsePacket"/> 对象,构造 <see cref="JsonResult"/> 对象
        /// </summary>
        /// <returns></returns>
        public static JsonResult CreateJsonResult(this PageModel model, ResponsePacket packet)
        {
            return new JsonResult(packet, JsonSerializer._Settings);
        }
        /// <summary>
        /// 通过指定的参数初始化 <see cref="ResponsePacket"/> 对象，并使用其构造 <see cref="JsonResult"/> 对象
        /// </summary>
        /// <param name="model"></param>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static JsonResult CreateJsonResult(this PageModel model, Boolean success, String message = null)
        {
            return new JsonResult(ResponsePacket.Create(success, message), JsonSerializer._Settings);
        }

        public static JsonResult CreateJsonResult(this PageModel model, Boolean success, Int32 state, String message = null)
        {
            return new JsonResult(ResponsePacket.Create(success, state, message), JsonSerializer._Settings);
        }

        /// <summary>
        /// 通过指定的参数初始化 <see cref="ResponsePacket{T}"/> 对象，并使用其构造 <see cref="JsonResult"/> 对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="success"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static JsonResult CreateJsonResult<T>(this PageModel model, Boolean success, T data, String message = null)
        {
            return new JsonResult(ResponsePacket.Create(success, message, data), JsonSerializer._Settings);
        }

        /// <summary>
        /// 通过指定的参数初始化 <see cref="ResponsePacket{T,T1}"/> 对象，并使用其构造 <see cref="JsonResult"/> 对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="model"></param>
        /// <param name="success"></param>
        /// <param name="data"></param>
        /// <param name="data1"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static JsonResult CreateJsonResult<T, T1>(this PageModel model, Boolean success, T data, T1 data1, String message = null)
        {
            return new JsonResult(ResponsePacket.Create(success, message, data, data1), JsonSerializer._Settings);
        }
    }

    public static class ControllerExtesion
    {
        /// <summary>
        ///  通过指定的 <see cref="ResponsePacket"/> 对象,构造 <see cref="JsonResult"/> 对象
        /// </summary>
        /// <returns></returns>
        public static JsonResult CreateJsonResult(this Controller model, ResponsePacket packet)
        {
            return new JsonResult(packet, JsonSerializer._Settings);
        }
        /// <summary>
        /// 通过指定的参数初始化 <see cref="ResponsePacket"/> 对象，并使用其构造 <see cref="JsonResult"/> 对象
        /// </summary>
        /// <param name="model"></param>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static JsonResult CreateJsonResult(this Controller model, Boolean success, String message = null)
        {
            return new JsonResult(ResponsePacket.Create(success, message), JsonSerializer._Settings);
        }

        /// <summary>
        /// 通过指定的参数初始化 <see cref="ResponsePacket{T}"/> 对象，并使用其构造 <see cref="JsonResult"/> 对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="success"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static JsonResult CreateJsonResult<T>(this Controller model, Boolean success, T data, String message = null)
        {
            return new JsonResult(ResponsePacket.Create(success, message, data), JsonSerializer._Settings);
        }

        /// <summary>
        /// 通过指定的参数初始化 <see cref="ResponsePacket{T,T1}"/> 对象，并使用其构造 <see cref="JsonResult"/> 对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="model"></param>
        /// <param name="success"></param>
        /// <param name="data"></param>
        /// <param name="data1"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static JsonResult CreateJsonResult<T, T1>(this Controller model, Boolean success, T data, T1 data1, String message = null)
        {
            return new JsonResult(ResponsePacket.Create(success, message, data, data1), JsonSerializer._Settings);
        }
    }
}
