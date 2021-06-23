// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: FrameworkException.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using System;
using System.Runtime.Serialization;

namespace FrameworkUnityPlugin
{
    /// <summary>
    /// 框架异常类。
    /// </summary>
    [Serializable]
    public class FrameworkException : Exception
    {
        public FrameworkException() : base()
        {
        }

        public FrameworkException(string message) : base(message)
        {
        }

        public FrameworkException(string message, params object[] args) : base(string.Format(message, args))
        {
        }

        public FrameworkException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public FrameworkException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

