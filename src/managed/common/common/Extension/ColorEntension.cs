// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: ColorEntension.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using UnityEngine;

namespace FrameworkUnityPlugin
{
    public static class ColorEntension
    {
        /// <summary>
        /// 转换成16进制格式字符串
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ToHexString(this Color color)
        {
            return Utility.Convert.GetColorString(color, true);
        }

        /// <summary>
        /// 转换成 RGB 格式字符串
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ToRGBString(this Color color)
        {
            return Utility.Convert.GetColorString(color, false);
        }

        /// <summary>
        /// 转换成16进制格式字符串
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ToHexString(this Color32 color)
        {
            return Utility.Convert.GetColorString(color, true);
        }

        /// <summary>
        /// 转换成 RGB 格式字符串
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ToRGBString(this Color32 color)
        {
            return Utility.Convert.GetColorString(color, false);
        }
    }
}
