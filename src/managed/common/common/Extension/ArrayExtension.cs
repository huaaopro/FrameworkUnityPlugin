// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: ArrayExtension.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

namespace FrameworkUnityPlugin
{
    public static class ArrayExtension
    {
        /// <summary>
        /// 合并数组。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static T[] Merge<T>(this T[] array1, T[] array2)
        {
            T[] result = new T[array1.Length + array2.Length];
            array1.CopyTo(result, 0);
            array2.CopyTo(result, array1.Length);
            return result;
        }

        /// <summary>
        /// 数组转换至指定类型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] To<T>(this object[] array)
        {
            int len = array.Length;
            T[] returnList = new T[len];
            for (int i = 0; i < len; i++) {
                returnList[i] = (T)array[i];
            }
            return returnList;
        }

        /// <summary>
        /// 随机数组。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void Shuffle<T>(params T[] array)
        {
            for (int i = 0; i < array.Length; i++) {
                var temp = array[i];
                var randomIndex = UnityEngine.Random.Range(0, array.Length);
                array[i] = array[randomIndex];
                array[randomIndex] = temp;
            }
        }

        /// <summary>
        /// 获取随机元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T GetRandom<T>(params T[] array)
        {
            return array[UnityEngine.Random.Range(0, array.Length)];
        }
    }
}
