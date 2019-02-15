using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Degage.Extension
{
    /// <summary>
    /// 存储枚举值相关颜色的元数据信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumColorAttribute : System.Attribute
    {
        /// <summary>
        /// 枚举值的颜色描述信息
        /// </summary>
        public Color Color { get; set; }

        public EnumColorAttribute()
        {

        }

        /// <summary>
        /// 使用颜色名称初始化 <see cref="EnumColorAttribute"/> 类的新实例
        /// </summary>
        /// <param name="colorName"></param>
        public EnumColorAttribute(String colorName) : this()
        {
            this.Color = Color.FromName(colorName);
        }

        /// <summary>
        /// 使用一个 32 位 ARGB 值初始化 <see cref="EnumColorAttribute"/> 类的新实例
        /// </summary>
        /// <param name="argb"></param>
        public EnumColorAttribute(Int32 argb) : this()
        {
            this.Color = Color.FromArgb(argb);
        }

        /// <summary>
        /// 使用指定的 8 位颜色值（红色、绿色和蓝色）初始化 <see cref="EnumColorAttribute"/> 类的新实例。alpha 值默认为 255（完全不透明） 
        /// </summary>
        /// <param name="argb"></param>
        public EnumColorAttribute(Int32 red, Int32 green, Int32 blue) : this()
        {
            this.Color = Color.FromArgb(red, green, blue);
        }

        /// <summary>
        /// 使用四个 ARGB 分量（alpha、红色、绿色和蓝色）值，初始化 <see cref="EnumColorAttribute"/> 类的新实例。
        /// </summary>
        /// <param name="argb"></param>
        public EnumColorAttribute(Int32 alpha, Int32 red, Int32 green, Int32 blue) : this()
        {
            this.Color = Color.FromArgb(alpha, red, green, blue);
        }
    }

}
