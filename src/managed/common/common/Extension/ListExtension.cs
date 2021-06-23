// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: ListExtension.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using System.Collections.Generic;

namespace FrameworkUnityPlugin
{
    public static class ListExtension
    {
        public static void Shuffle<T>(this IList<T> list, int? seed = null)
        {
            System.Random random = seed != null ? new System.Random((int)seed) : new System.Random();
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
