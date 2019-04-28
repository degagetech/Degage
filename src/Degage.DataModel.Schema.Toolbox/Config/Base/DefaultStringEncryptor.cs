using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.DataModel.Schema.Toolbox
{
    /// <summary>
    /// 提供对字符串简单的加解密功能(使用base64)
    /// </summary>
    public sealed class DefaultStringEncryptor
    {
        /// <summary>
        /// 对原始字符串进行简单加密
        /// </summary>
        public static String Encrypt(String original)
        {
            if (String.IsNullOrEmpty(original)) return original;
            Byte[] bytes = GetBytes(original);
            String encrypted = Convert.ToBase64String(bytes);
            return encrypted;
        }
        /// <summary>
        /// 对被此类加密的字符串进行解密
        /// </summary>
        public static String Decrypt(String original)
        {
            if (String.IsNullOrEmpty(original) && original.Length<4) return original;
            Byte[] bytes = Convert.FromBase64String(original);
            String decrypted = GetString(bytes);
            return decrypted;
        }


        private static String GetString(Byte[] bytes)
        {
            String str = UTF8Encoding.UTF8.GetString(bytes);
            return str;
        }
        private static Byte[] GetBytes(String str)
        {
            Byte[] bytes = UTF8Encoding.UTF8.GetBytes(str);
            return bytes;
        }
    }
}
