// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: Utitity.MathX.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using System;
using System.Text;

namespace FrameworkUnityPlugin
{
    public static partial class Utility
    {
        public static class MathX
        {
            public static int Add(int val1, int val2)
            {
                return val1 + val2;
            }

            public static int Sub(int val1, int val2)
            {
                return val1 - val2;
            }

            public static int Div(int val1, int val2)
            {
                return val1 / val2;
            }

            public static int Mul(int val1, int val2)
            {
                return val1 * val2;
            }
        }
    }
}