// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: SingletonGlobalMono.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using UnityEngine;

namespace FrameworkUnityPlugin
{
    /// <summary>
    /// 全局Mono单利.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonGlobalMono<T> : MonoBehaviour where T : SingletonGlobalMono<T>
    {
        private static T s_instance;

        public static T Instance
        {
            get {
                if (s_instance == null) {
                    s_instance = GameObject.FindObjectOfType<T>();
                    if (s_instance == null) {
                        s_instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
                    }
                    DontDestroyOnLoad(s_instance.gameObject);
                }
                return s_instance;
            }
        }

        protected virtual void Awake()
        {
            
        }

        protected virtual void Start()
        {

        }

        protected virtual void OnDestroy()
        {

        }
    }
}

