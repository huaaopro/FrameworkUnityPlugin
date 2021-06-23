// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: Utitity.Convert.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace FrameworkUnityPlugin
{
    public static partial class Utility
    {
        public static class Convert
        {
            // 1 inch = 2.54 cm
            private const float INCHES_TO_CENTIMETERS = 2.54f;

            // 1 cm = 0.3937 inches
            private const float CENTIMETERS_TO_INCHES = 1f / INCHES_TO_CENTIMETERS;

            /// <summary>
            /// 默认为小端。
            /// </summary>
            private static readonly bool IsLittleEndian = true;

            /// <summary>
            /// 类型转换。
            /// </summary>
            /// <remarks><c>T</c> 必须是原生类型</remarks>
            /// <param name="value"></param>
            /// <param name="defaultValue"></param>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public static T ChangeValue<T>(string value, T defaultValue = default(T))
            {
                if (null == value)
                {
                    return defaultValue;
                }

                Type type = typeof(T);

                if (type == typeof(string))
                {
                    return (T) (object) value;
                }

                if (!type.IsPrimitive)
                {
                    return defaultValue;
                }

                try
                {
                    return (T) System.Convert.ChangeType(value, type);
                }
                catch (Exception)
                {
                    return defaultValue;
                }
            }

            /// <summary>
            /// 对象数组类型转换。
            /// </summary>
            /// <remarks><c>T</c> 必须是原生类型</remarks>
            /// <param name="values"></param>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public static T[] ChangeValue<T>(string[] values)
            {
                List<T> result = new List<T>();

                if (null != values)
                {
                    Type type = typeof(T);

                    if (type == typeof(string))
                    {
                        return (T[]) (object) values;
                    }

                    if (type.IsPrimitive)
                    {
                        foreach (var val in values)
                        {
                            result.Add(ChangeValue<T>(val));
                        }
                    }
                }

                return result.ToArray();
            }

            /// <summary>
            /// 颜色转为可读字符串。
            /// </summary>
            /// <param name="color"></param>
            /// <param name="isColorHex"></param>
            /// <returns></returns>
            public static string GetColorString(Color color, bool isColorHex = true)
            {
                byte r = (byte) (color.r * 255f % 256);
                byte g = (byte) (color.g * 255f % 256);
                byte b = (byte) (color.b * 255f % 256);

                return isColorHex ? GetHexString(r, g, b) : GetRGBString(r, g, b);
            }

            /// <summary>
            /// 颜色转为可读字符串。
            /// </summary>
            /// <param name="color"></param>
            /// <param name="isColorHex"></param>
            /// <returns></returns>
            public static string GetColorString(Color32 color, bool isColorHex = true)
            {
                return isColorHex ? GetHexString(color.r, color.g, color.b) : GetRGBString(color.r, color.g, color.b);
            }

            /// <summary>
            /// 颜色转为 16 进制格式字符串。
            /// </summary>
            /// <param name="r"></param>
            /// <param name="g"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static string GetHexString(byte r, byte g, byte b)
            {
                return string.Format("{0:x2}{1:x2}{2:x2}", r, g, b);
            }

            /// <summary>
            /// 颜色转为 RGB 格式字符串
            /// </summary>
            /// <param name="r"></param>
            /// <param name="g"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static string GetRGBString(byte r, byte g, byte b)
            {
                return string.Format("rgb({0},{1},{2})", r, g, b);
            }

            /// <summary>
            /// 获取或设置屏幕每英寸点数。
            /// </summary>
            public static float ScreenDpi
            {
                get;
                set;
            }

            /// <summary>
            /// 将像素转换为厘米。
            /// </summary>
            /// <param name="pixels">像素</param>
            /// <returns>厘米</returns>
            public static float GetCentimetersFromPixels(float pixels)
            {
                if (ScreenDpi <= 0)
                {
                    throw new FrameworkException("You must set screen DPI first.");
                }

                return INCHES_TO_CENTIMETERS * pixels / ScreenDpi;
            }

            /// <summary>
            /// 将厘米转换为像素。
            /// </summary>
            /// <param name="centimeters">厘米</param>
            /// <returns>像素</returns>
            public static float Centimeters2Pixels(float centimeters)
            {
                if (ScreenDpi <= 0)
                {
                    throw new FrameworkException("You must set screen DPI first.");
                }

                return CENTIMETERS_TO_INCHES * centimeters * ScreenDpi;
            }

            /// <summary>
            /// 将像素转换为英寸。
            /// </summary>
            /// <param name="pixels">像素</param>
            /// <returns>英寸</returns>
            public static float Pixels2Inches(float pixels)
            {
                if (ScreenDpi <= 0)
                {
                    throw new FrameworkException("You must set screen DPI first.");
                }

                return pixels / ScreenDpi;
            }

            /// <summary>
            /// 将英寸转换为像素。
            /// </summary>
            /// <param name="inches">英寸</param>
            /// <returns>像素</returns>
            public static float Inches2Pixels(float inches)
            {
                if (ScreenDpi <= 0)
                {
                    throw new FrameworkException("You must set screen DPI first.");
                }

                return inches * ScreenDpi;
            }

            /// <summary>
            /// 返回字节数组中首个字节的布尔值。
            /// </summary>
            /// <param name="buffer"></param>
            /// <returns></returns>
            public static bool GetBool(byte[] buffer)
            {
                return GetBool(buffer, 0);
            }

            /// <summary>
            /// 返回字节数组中指定字节的布尔值。
            /// </summary>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static bool GetBool(byte[] buffer, int startPos)
            {
                if (buffer == null)
                {
                    throw new Exception("Buffer is null.");
                }

                if (startPos < 0)
                {
                    throw new Exception("StartPos ArgumentOutOfRange.");
                }

                if (startPos > buffer.Length - 1)
                {
                    throw new Exception("StartPos ArgumentOutOfRange");
                }

                return buffer[startPos] != (byte) 0;
            }

            /// <summary>
            /// 获取布尔值对应的字节数组。
            /// </summary>
            /// <param name="val"></param>
            /// <returns></returns>
            public static byte[] GetBytes(bool val)
            {
                byte[] buffer = new byte[1];
                GetBytes(val, buffer, 0);

                return buffer;
            }

            /// <summary>
            /// 获取布尔值对应的字节数组。
            /// </summary>
            /// <param name="val"></param>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            /// <exception cref="Exception"></exception>
            public static void GetBytes(bool val, byte[] buffer, int startPos)
            {
                if (buffer == null)
                {
                    throw new Exception("Buffer is null.");
                }

                if (startPos < 0)
                {
                    throw new Exception("StartPos ArgumentOutOfRange.");
                }

                if (startPos + 1 > buffer.Length)
                {
                    throw new Exception("StartPos ArgumentOutOfRange.");
                }

                buffer[startPos] = val ? (byte) 1 : (byte) 0;
            }

            /// <summary>
            /// 从字节数组中获取浮点数。
            /// </summary>
            /// <param name="buffer"></param>
            /// <returns></returns>
            public static float GetSingle(byte[] buffer)
            {
                return BitConverter.ToSingle(buffer, 0);
            }

            /// <summary>
            /// 从字节数组中指定位置获取浮点数。
            /// </summary>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            /// <returns></returns>
            public static float GetSingle(byte[] buffer, int startPos)
            {
                return BitConverter.ToSingle(buffer, startPos);
            }

            /// <summary>
            /// 将浮点数转换未字节数组。
            /// </summary>
            /// <param name="val"></param>
            /// <returns></returns>
            public static unsafe byte[] GetBytes(float val)
            {
                return GetBytes(*(int*) &val);
            }

            /// <summary>
            /// 以字节数组的形式获取浮点数。
            /// </summary>
            /// <param name="val"></param>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            public static unsafe void GetBytes(float val, byte[] buffer, int startPos)
            {
                GetBytes(*(int*) &val, buffer, startPos);
            }

            /// <summary>
            /// 从字节数组中获取整数。
            /// </summary>
            /// <param name="buffer"></param>
            /// <returns></returns>
            public static int GetInt32(byte[] buffer)
            {
                return BitConverter.ToInt32(buffer, 0);
            }

            /// <summary>
            /// 从字节数组中指定位置获取浮点数
            /// </summary>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            /// <returns></returns>
            public static int GetInt32(byte[] buffer, int startPos)
            {
                return BitConverter.ToInt32(buffer, startPos);
            }

            /// <summary>
            /// 获取整数的字节数组。
            /// </summary>
            /// <param name="val"></param>
            /// <returns></returns>
            public static byte[] GetBytes(int val)
            {
                byte[] buffer = new byte[4];
                GetBytes(val, buffer, 0);

                return buffer;
            }

            /// <summary>
            /// 以字节数组的形式获取整数。
            /// </summary>
            /// <param name="val"></param>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            /// <exception cref="Exception"></exception>
            public static unsafe void GetBytes(int val, byte[] buffer, int startPos)
            {
                if (buffer == null)
                {
                    throw new Exception("Buffer is null.");
                }

                if (startPos < 0)
                {
                    throw new Exception("StartPos ArgumentOutOfRange.");
                }

                if (startPos + 4 > buffer.Length)
                {
                    throw new Exception("StartPos ArgumentOutOfRange.");
                }

                fixed (byte* pBuffer = buffer)
                {
                    *(int*) (pBuffer + startPos) = val;
                }
            }

            /// <summary>
            /// 从字节数组中获取非负整数。
            /// </summary>
            /// <param name="buffer"></param>
            /// <returns></returns>
            public static uint GetUInt32(byte[] buffer)
            {
                return BitConverter.ToUInt32(buffer, 0);
            }

            /// <summary>
            /// 从字节数组的指定位置获取非负整数。
            /// </summary>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            /// <returns></returns>
            public static uint GetUInt32(byte[] buffer, int startPos)
            {
                return BitConverter.ToUInt32(buffer, startPos);
            }

            /// <summary>
            /// 获取非负整数的字节数组。
            /// </summary>
            /// <param name="val"></param>
            /// <returns></returns>
            public static byte[] GetBytes(uint val)
            {
                return GetBytes((int) val);
            }

            /// <summary>
            /// 以字节数组的形式获取非负整数。
            /// </summary>
            /// <param name="val"></param>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            public static void GetBytes(uint val, byte[] buffer, int startPos)
            {
                GetBytes((int) val, buffer, startPos);
            }

            /// <summary>
            /// 从字节数组中获取端整形。
            /// </summary>
            /// <param name="buffer"></param>
            /// <returns></returns>
            public static short GetInt16(byte[] buffer)
            {
                return GetInt16(buffer, 0);
            }

            /// <summary>
            /// 从字节数组指定位置获取短整型。
            /// </summary>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static unsafe short GetInt16(byte[] buffer, int startPos)
            {
                if (buffer == null)
                {
                    throw new Exception("Buffer is null.");
                }

                if (startPos < 0)
                {
                    throw new Exception("StartPos ArgumentOutOfRange.");
                }

                if (startPos > buffer.Length - 2)
                {
                    throw new Exception("StartPos ArgumentOutOfRange.");
                }

                fixed (byte* pBuffer = buffer)
                {
                    if (startPos % 2 == 0)
                    {
                        return *(short*) pBuffer;
                    }

                    if (IsLittleEndian)
                    {
                        return (short) ((int) *pBuffer | (int) pBuffer[1] << 8);
                    }

                    return (short) ((int) *pBuffer << 8 | (int) buffer[1]);
                }
            }

            /// <summary>
            /// 获取短整型的字节数组。
            /// </summary>
            /// <param name="val"></param>
            /// <returns></returns>
            public static byte[] GetBytes(short val)
            {
                byte[] buffer = new byte[2];
                GetBytes(val, buffer, 0);

                return buffer;
            }

            /// <summary>
            /// 以字节数组的形式获取短整型。
            /// </summary>
            /// <param name="val"></param>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            /// <exception cref="Exception"></exception>
            public static unsafe void GetBytes(short val, byte[] buffer, int startPos)
            {
                if (buffer == null)
                {
                    throw new Exception("Buffer is null.");
                }

                if (startPos < 0)
                {
                    throw new Exception("StartPos ArgumentOutOfRange.");
                }

                if (startPos + 2 > buffer.Length)
                {
                    throw new Exception("StartPos ArgumentOutOfRange.");
                }

                fixed (byte* pBuffer = buffer)
                {
                    *(short*) (pBuffer + startPos) = val;
                }
            }

            /// <summary>
            /// 从字节数组中获取非负端整形。
            /// </summary>
            /// <param name="buffer"></param>
            /// <returns></returns>
            public static ushort GetUInt16(byte[] buffer)
            {
                return BitConverter.ToUInt16(buffer, 0);
            }

            /// <summary>
            /// 从字节数组指定位置获取非负端整型。
            /// </summary>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            /// <returns></returns>
            public static ushort GetUInt16(byte[] buffer, int startPos)
            {
                return BitConverter.ToUInt16(buffer, startPos);
            }

            /// <summary>
            /// 获取非负短整型的字节数组。
            /// </summary>
            /// <param name="val"></param>
            /// <returns></returns>
            public static byte[] GetBytes(ushort val)
            {
                return GetBytes((short) val);
            }

            /// <summary>
            /// 以字节数组的形式获取非负短整数。
            /// </summary>
            /// <param name="val"></param>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            public static void GetBytes(ushort val, byte[] buffer, int startPos)
            {
                GetBytes((short) val, buffer, startPos);
            }

            /// <summary>
            /// 从字节数组中获取双精度浮点数。
            /// </summary>
            /// <param name="buffer"></param>
            /// <returns></returns>
            public static double GetDouble(byte[] buffer)
            {
                return BitConverter.ToDouble(buffer, 0);
            }

            /// <summary>
            /// 从字节数组指定位置获取双精度浮点数。
            /// </summary>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            /// <returns></returns>
            public static double GetDouble(byte[] buffer, int startPos)
            {
                return BitConverter.ToDouble(buffer, startPos);
            }

            /// <summary>
            /// 获取双精度浮点数的字节数组。
            /// </summary>
            /// <param name="val"></param>
            /// <returns></returns>
            public static unsafe byte[] GetBytes(double val)
            {
                return GetBytes(*(long*) (&val));
            }

            /// <summary>
            /// 以字节数组的形式获取双精度浮点数。
            /// </summary>
            /// <param name="val"></param>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            public static unsafe void GetBytes(double val, byte[] buffer, int startPos)
            {
                GetBytes(*(long*) (&val), buffer, startPos);
            }

            /// <summary>
            /// 从字节数组中获取长整型。
            /// </summary>
            /// <param name="buffer"></param>
            /// <returns></returns>
            public static long GetInt64(byte[] buffer)
            {
                return BitConverter.ToInt64(buffer, 0);
            }

            /// <summary>
            /// 从字节数组指定位置获取长整型。
            /// </summary>
            /// <param name="buffer"></param>
            /// <param name="startPos"></param>
            /// <returns></returns>
            public static long GetInt64(byte[] buffer, int startPos)
            {
                return BitConverter.ToInt64(buffer, startPos);
            }

            public static byte[] GetBytes(long val)
            {
                byte[] buffer = new byte[8];
                GetBytes(val, buffer, 0);

                return buffer;
            }

            public static unsafe void GetBytes(long val, byte[] buffer, int startPos)
            {
                if (buffer == null)
                {
                    throw new Exception("Buffer is null.");
                }

                if (startPos < 0)
                {
                    throw new Exception("StartPos ArgumentOutOfRange.");
                }

                if (startPos + 8 > buffer.Length)
                {
                    throw new Exception("StartPos ArgumentOutOfRange.");
                }

                fixed (byte* pBuffer = buffer)
                {
                    *(long*) (pBuffer + startPos) = val;
                }
            }

            public static ulong GetUInt64(byte[] buffer)
            {
                return BitConverter.ToUInt64(buffer, 0);
            }

            public static ulong GetUInt64(byte[] buffer, int startPos)
            {
                return BitConverter.ToUInt64(buffer, startPos);
            }

            public static byte[] GetBytes(ulong val)
            {
                return GetBytes((long) val);
            }

            public static void GetBytes(ulong val, byte[] buffer, int startPos)
            {
                GetBytes((long) val, buffer, startPos);
            }

            public static byte[] GetBytes(string val)
            {
                if (val == null)
                {
                    throw new FrameworkException("Val is invalid.");
                }

                return Encoding.UTF8.GetBytes(val);
            }

            public static byte[] GetBytes(string val, Encoding encoding)
            {
                if (val == null)
                {
                    throw new FrameworkException("Val is invalid.");
                }

                if (encoding == null)
                {
                    throw new FrameworkException("Encoding is invalid.");
                }

                return encoding.GetBytes(val);
            }

            public static int GetBytes(string val, byte[] buffer)
            {
                if (val == null)
                {
                    throw new FrameworkException("Val is invalid.");
                }

                if (buffer == null)
                {
                    throw new FrameworkException("Buffer is invalid.");
                }

                return GetBytes(val, buffer, 0, Encoding.UTF8);
            }

            public static int GetBytes(string val, byte[] buffer, int startPos, Encoding encoding)
            {
                if (val == null)
                {
                    throw new FrameworkException("Val is invalid.");
                }

                if (buffer == null)
                {
                    throw new FrameworkException("Buffer is invalid.");
                }

                if (encoding == null)
                {
                    throw new FrameworkException("Encoding is invalid.");
                }

                return encoding.GetBytes(val, 0, val.Length, buffer, startPos);
            }

            public static string GetString(byte[] buffer)
            {
                return GetString(buffer, Encoding.UTF8);
            }

            public static string GetString(byte[] buffer, Encoding encoding)
            {
                if (buffer == null)
                {
                    throw new FrameworkException("Buffer is invalid.");
                }

                if (encoding == null)
                {
                    throw new FrameworkException("Encoding is invalid.");
                }

                return encoding.GetString(buffer);
            }

            public static string GetString(byte[] buffer, int startPos, int length)
            {
                return GetString(buffer, startPos, length, Encoding.UTF8);
            }

            public static string GetString(byte[] buffer, int startPos, int length, Encoding encoding)
            {
                if (buffer == null)
                {
                    throw new FrameworkException("Buffer is invalid.");
                }

                if (encoding == null)
                {
                    throw new FrameworkException("Encoding is invalid.");
                }

                return encoding.GetString(buffer, startPos, length);
            }

            /// <summary>
            /// 把整数间的某几位置为定义值,右边第一位 索引为0 左边最后一位索引为31
            /// </summary>
            /// <param name="s"></param>
            /// <param name="startPos">开始位  从右到左</param>
            /// <param name="value">值 大于等于0   低位在startPos, 左边为高位 右边为低位</param>
            /// <param name="overWriteLength">值覆盖长度，从右到左</param>
            /// <returns></returns>
            public static int SetBitValue(int s, int startPos, int value, int overWriteLength)
            {
                if (value < 0 || startPos < 0 || startPos > 31)
                {
                    throw new FrameworkException("Param not legal");
                }

                return (~(~(-1 << overWriteLength) << startPos) & s) | (value << startPos);
            }

            /// <summary>
            /// 得到一个整数间某几个位的值
            /// </summary>
            /// <param name="s"></param>
            /// <param name="startPos">开始位  从右到左</param>
            /// <param name="length">从右到左的长度，左边为高位 右边为低位</param>
            /// <returns></returns>
            public static int GetBitValue(int s, int startPos, int length)
            {
                return ((~(-1 << length) << startPos) & s) >> startPos;
            }

            /// <summary>
            /// 将字节数组转换为16进制字符串
            /// </summary>
            /// <param name="s">字节数组</param>
            /// <returns>字符数组</returns>
            public static char[] ChangeByte2HpyChar(byte[] s)
            {
                char[] r = new char[s.Length * 2];

                for (int i = 0; i < s.Length; i++)
                {
                    r[i * 2] = ChangeHyp2Char((s[i] >> 4) & 0x0F);
                    r[i * 2 + 1] = ChangeHyp2Char(s[i] & 0x0F);
                }

                return r;
            }

            /// <summary>
            /// 将16进制字符数组转为字节数组
            /// </summary>
            /// <param name="s">字符数组</param>
            /// <returns>字节数组</returns>
            public static byte[] ChangeChar2Hpy(char[] s)
            {
                byte[] r = new byte[s.Length / 2];

                for (int i = 0; i < r.Length; i++)
                {
                    r[i] = (byte) (ChangeHpyChar2Byte(s[i * 2]) << 4 | ChangeHpyChar2Byte(s[i * 2 + 1]));
                }

                return r;
            }

            /// <summary>
            /// 将16进制字符转换为数字。
            /// </summary>
            /// <param name="val">字符</param>
            /// <returns>返回数字</returns>
            public static byte ChangeHpyChar2Byte(char val)
            {
                if (val > 57)
                {
                    return (byte) (val - 87);
                }
                else
                {
                    return (byte) (val - 48);
                }
            }

            /// <summary>
            /// 将数字转换成16进制。
            /// </summary>
            /// <param name="val">数字</param>
            /// <returns>返回字符</returns>
            public static char ChangeHyp2Char(int val)
            {
                if (val < 0 || val > 15)
                {
                    throw new FrameworkException("Param is invalid.");
                }

                if (val < 10)
                {
                    return (char) (48 + val);
                }
                else
                {
                    return (char) (87 + val);
                }
            }
        }
    }
}