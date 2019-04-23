using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Degage.Native.Windows
{

    /// <summary>
    /// 表示调用系统本地 Api 时返回的结果
    /// </summary>
    internal abstract class NativeApiResult
    {
        /// <summary>
        /// 获取调用线程最后一次发生的错误
        /// </summary>
        /// <returns></returns>
        public static Int32 GetLastError()
        {
            return Marshal.GetLastWin32Error();
        }

        /// <summary>
        /// 创建一个指定类型参数、结果、以及错误编码值的本地调用结果对象
        /// </summary>
        /// <typeparam name="TResult">结果类型</typeparam>
        /// <param name="result">结果值</param>
        /// <param name="errorCodeValue">错误编码值</param>
        /// <returns></returns>
        public static NativeApiResult<TResult> Create<TResult>(TResult result, Int32 errorCodeValue = (Int32)LastErrorCode.Normal)
        {
            return new NativeApiResult<TResult>(result, errorCodeValue);
        }
        /// <summary>
        /// 创建一个指定类型参数、结果、结果2以及错误编码值的本地调用结果对象
        /// </summary>
        /// <typeparam name="TResult">结果类型</typeparam>
        /// <typeparam name="TResult2">结果类型2</typeparam>
        /// <param name="result">结果值</param>
        /// <param name="result2">结果值2</param>
        /// <param name="errorCodeValue">错误编码值</param>
        /// <returns></returns>
        public static NativeApiResult<TResult, TResult2> Create<TResult, TResult2>(TResult result, TResult2 result2, Int32 errorCodeValue = (Int32)LastErrorCode.Normal)
        {
            return new NativeApiResult<TResult, TResult2>(result, result2, errorCodeValue);
        }
    }
    /// <summary>
    /// 表示调用系统本地 Api 时返回的结果
    /// </summary>
    public class NativeApiResult<TResult>
    {

        /// <summary>
        /// 使用指定的调用结果、以及错误编码值构造 <see cref="NativeApiResult{TResult}"/> 类的实例
        /// </summary>
        /// <param name="result">调用结果</param>
        /// <param name="errorCodeValue">调用后，调用线程最后发送的错误的编码值</param>
        public NativeApiResult(TResult result, Int32 errorCodeValue = (Int32)LastErrorCode.Normal)
        {
            this.Result = result;
            this.ErrorCodeValue = errorCodeValue;
        }
        /// <summary>
        /// 表示调用成功与否，当 <see cref="ErrorCode"/> 不等于 <see cref="LastErrorCode.Normal"/> 时，此值为 false,否则为 true。
        /// </summary>
        public Boolean Success { get; private set; } = true;
        /// <summary>
        /// 调用返回的结果
        /// </summary>
        public TResult Result { get; internal set; }
        /// <summary>
        ///当 API 调用失败时，调用线程最后发生的错误的编码，设置此属性时 <see cref="ErrorCodeValue"/> 的值也会改变，此值也会影响到 <see cref="Success"/> 标识
        /// </summary>
        public LastErrorCode ErrorCode
        {
            get
            {
                return _errorCode;
            }
            internal set
            {
                _errorCode = value;
                this._errorCodeValue = (Int32)value;
                if (value == LastErrorCode.Normal)
                {
                    this.Success = true;
                }
                else
                {
                    this.Success = false;
                }

            }
        }
        private LastErrorCode _errorCode = LastErrorCode.Normal;

        /// <summary>
        /// 错误编码的值，
        /// 设置此属性时，
        /// 如果再 <see cref="LastErrorCode"/> 中有对应值，则 <see cref="ErrorCode"/> 属性将被设置为对应值，
        /// 否则设置为 <see cref="LastErrorCode.UnKnown"/>，
        /// 此值也会影响到 <see cref="Success"/> 标识
        /// </summary>
        public Int32 ErrorCodeValue
        {
            get
            {
                return _errorCodeValue;
            }
            internal set
            {
                this._errorCodeValue = value;
                if (value == (Int32)LastErrorCode.Normal)
                {
                    this.Success = true;
                }
                else
                {
                    this.Success = false;
                }
                if (Enum.IsDefined(typeof(LastErrorCode), value))
                {
                    this._errorCode = (LastErrorCode)value;
                }
                else
                {
                    this._errorCode = LastErrorCode.UnKnown;
                }
            }
        }
        private Int32 _errorCodeValue;
    }

    public class NativeApiResult<TResult, TResult2> : NativeApiResult<TResult>
    {
        /// <summary>
        /// 调用返回的结果2
        /// </summary>
        public TResult2 Result2 { get; internal set; }

        /// <summary>
        /// 使用指定的调用结果、以及另一个调用结果、错误编码值构造 <see cref="NativeApiResult{TResult,TResult2}"/> 类的实例
        /// </summary>
        /// <param name="result"></param>
        /// <param name="result2"></param>
        /// <param name="errorCodeValue"></param>
        public NativeApiResult(TResult result, TResult2 result2, Int32 errorCodeValue = (Int32)LastErrorCode.Normal)
            : base(result, errorCodeValue)
        {
            this.Result2 = result2;
        }
    }
}
