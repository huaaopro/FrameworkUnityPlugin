// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: GameObjectExtension.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using System;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkUnityPlugin
{
    public static class GameObjectExtension
    {
        /// <summary>
        /// 获取 GameObject 是否在场景中
        /// </summary>
        /// <param name="gameObject">目标对象</param>
        /// <returns>GameObject 是否在场景中</returns>
        /// <remarks>若返回 true，表明此 GameObject 是一个场景中的实例对象；若返回 false，表明此 GameObject 是一个 Prefab</remarks>
        public static bool InScene(this GameObject gameObject)
        {
            return gameObject.scene.name != null;
        }

        /// <summary>
        /// 获取对象资源
        /// </summary>
        /// <param name="go"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetOrAddComponent<T>(this GameObject go) where T : Component
        {
            T t = go.GetComponent<T>();
            if (t == null) {
                t = go.AddComponent<T>();
            }
            return t;
        }

        /// <summary>
        /// 获取对象资源
        /// </summary>
        /// <param name="go"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Component GetOrAddComponent(this GameObject go, Type type)
        {
            Component t = go.GetComponent(type);
            if (t == null) {
                t = go.AddComponent(type);
            }
            return t;
        }

        /// <summary>
        /// 添加唯一的组件，已经存在的组件会被先删除
        /// </summary>
        /// <param name="go"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetOrAddSoleComponent<T>(this GameObject go) where T : Component
        {
            T[] array = go.GetComponents<T>();
            for (int i = 0; i < array.Length; ++i) {
                UnityEngine.Object.Destroy(array[i]);
            }
            return go.AddComponent<T>();
        }

        /// <summary>
        /// 查找指定组件
        /// </summary>
        /// <param name="go"></param>
        /// <param name="path"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FindComponent<T>(this GameObject go, string path) where T : Component
        {
            return go.transform.FindComponent<T>(path);
        }

        /// <summary>
        /// 获取材质对象
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public static Material GetMaterial(this GameObject go)
        {
            var renderer = go.GetComponent<Renderer>();
            return null != renderer ? renderer.material : null;
        }

        /// <summary>
        /// 获取共享材质对象
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public static Material GetSharedMaterial(this GameObject go)
        {
            var renderer = go.GetComponent<Renderer>();
            return null != renderer ? renderer.sharedMaterial : null;
        }

        /// <summary>
        /// 获取所有材质对象
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public static Material[] GetAllMaterials(this GameObject go)
        {
            var materials = new List<Material>();
            var renderers = go.GetComponentsInChildren<Renderer>();

            foreach (var r in renderers)
                materials.AddRange(r.materials);

            return materials.ToArray();
        }

        /// <summary>
        /// 获取所有共享材质对象
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public static Material[] GetAllSharedMaterials(this GameObject go)
        {
            List<Material> materials = new List<Material>();
            Renderer[] renderers = go.GetComponentsInChildren<Renderer>();

            foreach (var r in renderers)
                materials.AddRange(r.sharedMaterials);

            return materials.ToArray();
        }

        /// <summary>
        /// 设置对象的层级
        /// </summary>
        /// <param name="go"></param>
        /// <param name="layer"></param>
        /// <param name="includeChild"></param>
        public static void SetLayer(this GameObject go, int layer, bool includeChild = true)
        {
            go.layer = layer;

            if (!includeChild) {
                return;
            }

            var transform = go.transform;
            for (int i = 0, count = transform.childCount; i < count; ++i) {
                var child = transform.GetChild(i);
                child.gameObject.SetLayer(layer);
            }
        }

        /// <summary>
        /// 添加子对象
        /// </summary>
        /// <param name="go"></param>
        /// <param name="child"></param>
        /// <param name="worldPositionStays"></param>
        public static void AddChild(this GameObject go, GameObject child, bool worldPositionStays = false)
        {
            go.transform.AddChild(child.transform, worldPositionStays);
        }

        /// <summary>
        /// 销毁对象所有子对象
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="isImmediateDesctroy"></param>
        public static void DestroyChildren(this GameObject gameObject, bool isImmediateDesctroy = true)
        {
            if (gameObject == null) {
                return;
            }

            gameObject.transform.DestroyChildren();
        }
    }
}
