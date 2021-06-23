// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: SingletonSingleMono.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using UnityEngine;

namespace FrameworkUnityPlugin
{
    /// <summary>
    /// 单场景Mono单利
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonSingleMono<T> : MonoBehaviour where T : SingletonSingleMono<T>
    {
        private static T s_instance;

        public static T Instance
        {
            get {
                if(s_instance == null) {
                    s_instance = GameObject.FindObjectOfType<T>();
                    if(s_instance == null) {
                        s_instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
                    }
                }
                return s_instance;
            }
        }

        protected virtual void Awake()
        {

        }

        protected virtual void OnDestroy()
        {
            
        }
    }
}
