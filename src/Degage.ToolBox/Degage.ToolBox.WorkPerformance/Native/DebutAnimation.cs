#define WINDOWS_DEBUT
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace WorkPerformance
{


#if WINDOWS_DEBUT
    /// <summary>
    /// 控件的出场、退场动画效果
    /// </summary>
    public enum DebutEffects
    {
        SliderLeftToRight = Animator.AW_SLIDE | Animator.AW_HOR_POSITIVE,
        SliderRightToLeft = Animator.AW_SLIDE | Animator.AW_HOR_NEGATIVE,
        SliderTopToBottom = Animator.AW_SLIDE | Animator.AW_VER_POSITIVE,
        SliderBottomToTop = Animator.AW_SLIDE | Animator.AW_VER_NEGATIVE,
        Center = Animator.AW_CENTER,

        /// <summary>
        ///淡入淡出， 只能为顶层控件使用此效果
        /// </summary>
        Fade = Animator.AW_BLEND,

        /// <summary>
        ///出场，为顶层控件指定动画效果时需自行判断附加此效果
        /// </summary>
        Debut = Animator.AW_ACTIVATE,
        /// <summary>
        /// 退场，为顶层控件指定动画效果时需自行判断附加此效果
        /// </summary>
        WalkOff = Animator.AW_HIDE
    }

    /// <summary>
    /// 提供动画相关函数
    /// </summary>
    public static class Animator
    {
        /// <summary>
        /// 为指定控件的显示、隐藏使用相应动画效果
        /// </summary>
        /// <param name="ctl">需要使用动画的控件</param>
        /// <param name="effect">动画效果</param>
        /// <param name="time">表示动画持续的时间单位 ms</param>
        /// <param name="auto">表示是否自行判断指定控件当前应使用出场还是退场效果，当控件为顶层控件时此参数无效</param>
        public static void DebutAnimation(this Control ctl, DebutEffects effect, Int32 time = 200, Boolean auto = true)
        {
            Boolean isDebut = false;
            Int32 flags = (Int32)effect;

            Boolean isTop = false;
            if (ctl.TopLevelControl == ctl)
            {
                isTop = true;
                auto = false;
            }
            if (auto)
            {
                isDebut = !ctl.Visible;
                flags |= (isDebut ? AW_ACTIVATE : AW_HIDE);
            }
            Animator.AnimateWindow(ctl, time, flags);
            if (!isTop)
                ctl.Visible = isDebut;

        }

        public static Boolean AnimateWindow(Control control, Int32 time, Int32 flags)
        {
            Boolean success = false;
            success = Animator.AnimateWindow(control.Handle, time, flags);
            return success;
        }
        /// <summary>
        /// 该函数能在显示与隐藏窗口时能产生特殊的效果。
        /// </summary>
        /// <param name="handle">指定产生动画的窗口的句柄。</param>
        /// <param name="dwTime">指明动画持续的时间（以微秒计），完成一个动画的标准时间为200微秒。</param>
        /// <param name="dwFags">指定动画类型。这个参数可以是一个或多个下列标志的组合。标志描述：</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        public static extern Boolean AnimateWindow(IntPtr handle, Int32 dwTime, Int32 dwFags);

        /// <summary>
        ///自左向右显示窗口。该标志可以在滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        /// </summary>
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        /// <summary>
        ///  自右向左显示窗口。该标志可以在滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        /// </summary>
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        /// <summary>
        /// 自顶向下显示窗口。该标志可以在滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        /// </summary>
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        /// <summary>
        /// 自下向上显示窗口。该标志可以在滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        /// </summary>
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        /// <summary>
        /// 若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展。
        /// </summary>
        public const Int32 AW_CENTER = 0x00000010;
        /// <summary>
        /// 隐藏窗口，缺省则显示窗口。
        /// </summary>
        public const Int32 AW_HIDE = 0x00010000;
        /// <summary>
        /// 激活窗口。在使用了AW_HIDE标志后不要使用这个标志。
        /// </summary>
        public const Int32 AW_ACTIVATE = 0x00020000;
        /// <summary>
        /// 使用滑动类型。缺省则为滑动动画类型。当使用AW_CENTER标志时，这个标志就被忽略。
        /// </summary>
        public const Int32 AW_SLIDE = 0x00040000;
        /// <summary>
        /// 使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。
        /// </summary>
        public const Int32 AW_BLEND = 0x00080000;

    }

#endif

}
