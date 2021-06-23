// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: ClassExtension.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using System;
using System.Collections.Generic;
using System.Reflection;

namespace FrameworkUnityPlugin
{
    public static class ClassExtension
    {
        /// <summary>
        /// 获取所有子类类型数组 （注意性能问题）
        /// </summary>
        /// <param name="parentType">父类类型</param>
        /// <returns>返回子类类型数组</returns>
        public static Type[] GetChildTypes(this Type parentType)
        {

            List<Type> lstType = new List<Type>();
            Assembly assem = Assembly.GetAssembly(parentType);

            foreach (Type tChild in assem.GetTypes()) {
                if (tChild.BaseType == parentType) {
                    lstType.Add(tChild);
                }
            }

            return lstType.ToArray();
        }

        /// <summary>
        /// 获取子类类型名称数组 （注意性能问题）
        /// </summary>
        /// <param name="parentType">父类类型</param>
        /// <returns>返回子类名称数组</returns>
        public static string[] GetChildTypesName(this Type parentType)
        {
            List<string> lstType = new List<string>();
            Assembly assembly = Assembly.Load("Assembly-CSharp");

            foreach (Type tChild in assembly.GetTypes()) {
                if (tChild.BaseType == parentType) {
                    lstType.Add(tChild.FullName);
                }
            }

            return lstType.ToArray();
        }

        /// <summary>
        /// 获取所有接口子类型数组
        /// </summary>
        /// <param name="interfaceType">接口类型</param>
        /// <returns>返回类型数组</returns>
        public static Type[] GetChildTypesWithInterface(this Type interfaceType)
        {
            List<Type> lstType = new List<Type>();
            Assembly assembly = Assembly.GetAssembly(interfaceType);

            foreach (Type tChild in assembly.GetTypes()) {
                foreach (Type tInterface in tChild.GetInterfaces()) {
                    if (tInterface == interfaceType) {
                        lstType.Add(tChild);
                    }
                }
            }

            return lstType.ToArray();
        }

        /// <summary>
        /// 获取所有接口子类型名称数组
        /// </summary>
        /// <param name="interfaceType">接口类型</param>
        /// <returns>返回类型名称数组</returns>
        public static string[] GetChildTypesNameWithInterface(this Type interfaceType)
        {
            List<string> lstType = new List<string>();
            Assembly assembly = Assembly.GetAssembly(interfaceType);

            foreach (Type tChild in assembly.GetTypes()) {
                foreach (Type tInterface in tChild.GetInterfaces()) {
                    if (tInterface == interfaceType) {
                        lstType.Add(tChild.FullName);
                    }
                }
            }

            return lstType.ToArray();
        }
    }
}
