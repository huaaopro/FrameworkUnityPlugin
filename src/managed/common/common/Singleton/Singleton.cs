// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: Singleton.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkUnityPlugin
{
    /// <summary>
    /// 单例模式的基类
    /// </summary>
    /// <remarks>如非必须，不建议使用单例模式</remarks>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T> where T : class
    {
        private static T s_Instance;

        protected Singleton()
        {
            New();
        }

        /// <summary>
        /// 获取该类型的单例对象实例。
        /// </summary>
        public static T Instance
        {
            get {
                return s_Instance != default(T) ? s_Instance : (s_Instance = (T)Activator.CreateInstance(typeof(T)));
            }
        }

        /// <summary>
        /// 对象实例化时调用。
        /// </summary>
        protected virtual void New()
        {

        }

        /// <summary>
        /// 销毁对象实例。
        /// </summary>
        public static void Destory()
        {
            s_Instance = default(T);
        }
    }
}
