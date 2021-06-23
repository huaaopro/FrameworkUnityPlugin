// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: StringExtension.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using System;
using System.Collections.Generic;

namespace FrameworkUnityPlugin
{
    public static class StringExtension
    {
        /// <summary>
        /// 空字符串数组
        /// </summary>
        public static readonly string[] EMPTY_STRING_ARRAY = { };

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="s">字符串</param>
        /// <param name="segment">分隔符</param>
        /// <returns></returns>
        public static T[] SplitToArray<T>(this string s, char segment = '|') where T : struct
        {
            if (string.IsNullOrEmpty(s)) {
                return null;
            }

            try {
                string[] strArr = s.Split(segment);
                int count = strArr.Length;
                T[] tArray = new T[count];
                for (int i = 0; i < count; i++) {
                    tArray[i] = (T)Convert.ChangeType(strArr[i], typeof(T));
                }
                return tArray;
            } catch (Exception ex) {
                throw new FrameworkException("{0} can't convert target {1}, {2}", s, typeof(T).Name, ex.Message);
            }
        }

        /// <summary>
        /// 将文本按行切分
        /// </summary>
        /// <param name="sText">要切分的文本</param>
        /// <returns>按行切分后的文本</returns>
        public static string[] SplitToLines(this string sText)
        {
            List<string> texts = new List<string>();
            int position = 0;
            string rowText = null;
            while ((rowText = sText.ReadLine(ref position)) != null) {
                texts.Add(rowText);
            }

            return texts.ToArray();
        }

        /// <summary>
        /// 读取一行文本
        /// </summary>
        /// <param name="text">要读取的文本</param>
        /// <param name="position">开始的位置</param>
        /// <returns>一行文本</returns>
        public static string ReadLine(this string text, ref int position)
        {
            if (text == null) {
                return null;
            }
            int length = text.Length;
            int offset = position;
            while (offset < length) {
                char ch = text[offset];
                switch (ch) {
                    case '\r':
                    case '\n':
                        string str = text.Substring(position, offset - position);
                        position = offset + 1;
                        if (((ch == '\r') && (position < length)) && (text[position] == '\n')) {
                            position++;
                        }

                        return str;
                    default:
                        offset++;
                        break;
                }
            }

            if (offset > position) {
                string str = text.Substring(position, offset - position);
                position = offset;
                return str;
            }
            return null;
        }

        /// <summary>
        /// 分割字符串为特定类型
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="segment">分隔符</param>
        /// <returns>返回字符串</returns>
        public static string[] SplitToArray(this string s, char segment = '|')
        {
            if (string.IsNullOrEmpty(s)) {
                return null;
            }

            string[] array = s.Split(segment);
            for (int i = 0, len = array.Length; i < len; ++i) {
                array[i] = array[i].Trim();
            }

            return array;
        }

        /// <summary>
        ///  字符串首字母大写
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns>返回字符串</returns>
        public static string ToTitleCase(this string s)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s);
        }
    }
}
