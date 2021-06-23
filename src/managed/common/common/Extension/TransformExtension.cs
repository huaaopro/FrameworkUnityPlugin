// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: TransformExtension.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using System.Collections.Generic;
using UnityEngine;

namespace FrameworkUnityPlugin
{
    public static class TransformExtension
    {
        /// <summary>
        /// 重置Transform
        /// </summary>
        /// <param name="transform"></param>
        public static void Reset(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        /// <summary>
        /// 获取组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="transform"></param>
        /// <returns></returns>
        public static T AddMissComponent<T>(this Transform transform) where T : Component
        {
            T t = transform.GetComponent<T>();
            if (t == null) {
                t = transform.gameObject.AddComponent<T>();
            }
            return t;
        }

        /// <summary>
        /// 查找指定组件
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="path"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FindComponent<T>(this Transform transform, string path) where T : Component
        {
            var child = transform.Find(path);
            return null != child ? child.GetComponent<T>() : null;
        }

        /// <summary>
        /// 添加子对象。
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="child"></param>
        /// <param name="worldPositionStays"></param>
        public static void AddChild(this Transform transform, Transform child, bool worldPositionStays = false)
        {
            child.SetParent(transform, worldPositionStays);
            child.Reset();
            child.gameObject.SetLayer(transform.gameObject.layer);
        }

        /// <summary>
        /// 销毁对象所有子对象。
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="isImmediateDesctroy"></param>
        public static void DestroyChildren(this Transform transform, bool isImmediateDesctroy = true)
        {
            if (transform == null) {
                return;
            }

            int childCount = transform.childCount;
            List<GameObject> tmpList = new List<GameObject>();
            for (int i = 0; i < childCount; i++) {
                tmpList.Add(transform.GetChild(i).gameObject);
            }

            foreach (GameObject obj in tmpList) {
                if (isImmediateDesctroy) {
                    GameObject.DestroyImmediate(obj);
                } else {
                    GameObject.Destroy(obj);
                }
            }
        }

        /// <summary>
        /// 设置绝对位置的 x 坐标
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="newValue">x 坐标值</param>
        public static void SetPositionX(this Transform transform, float newValue)
        {
            Vector3 v = transform.position;
            v.x = newValue;
            transform.position = v;
        }

        /// <summary>
        /// 设置绝对位置的 y 坐标
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="newValue">y 坐标值</param>
        public static void SetPositionY(this Transform transform, float newValue)
        {
            Vector3 v = transform.position;
            v.y = newValue;
            transform.position = v;
        }

        /// <summary>
        /// 设置绝对位置的 z 坐标
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="newValue">z 坐标值</param>
        public static void SetPositionZ(this Transform transform, float newValue)
        {
            Vector3 v = transform.position;
            v.z = newValue;
            transform.position = v;
        }

        /// <summary>
        /// 增加绝对位置的 x 坐标
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="deltaValue">x 坐标值增量</param>
        public static void AddPositionX(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.position;
            v.x += deltaValue;
            transform.position = v;
        }

        /// <summary>
        /// 增加绝对位置的 y 坐标
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="deltaValue">y 坐标值增量</param>
        public static void AddPositionY(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.position;
            v.y += deltaValue;
            transform.position = v;
        }

        /// <summary>
        /// 增加绝对位置的 z 坐标
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="deltaValue">z 坐标值增量</param>
        public static void AddPositionZ(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.position;
            v.z += deltaValue;
            transform.position = v;
        }

        /// <summary>
        /// 设置相对位置的 x 坐标
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="newValue">x 坐标值</param>
        public static void SetLocalPositionX(this Transform transform, float newValue)
        {
            Vector3 v = transform.localPosition;
            v.x = newValue;
            transform.localPosition = v;
        }

        /// <summary>
        /// 设置相对位置的 y 坐标
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="newValue">y 坐标值</param>
        public static void SetLocalPositionY(this Transform transform, float newValue)
        {
            Vector3 v = transform.localPosition;
            v.y = newValue;
            transform.localPosition = v;
        }

        /// <summary>
        /// 设置相对位置的 z 坐标
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="newValue">z 坐标值</param>
        public static void SetLocalPositionZ(this Transform transform, float newValue)
        {
            Vector3 v = transform.localPosition;
            v.z = newValue;
            transform.localPosition = v;
        }

        /// <summary>
        /// 增加相对位置的 x 坐标
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="deltaValue">x 坐标值</param>
        public static void AddLocalPositionX(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.localPosition;
            v.x += deltaValue;
            transform.localPosition = v;
        }

        /// <summary>
        /// 增加相对位置的 y 坐标
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="deltaValue">y 坐标值</param>
        public static void AddLocalPositionY(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.localPosition;
            v.y += deltaValue;
            transform.localPosition = v;
        }

        /// <summary>
        /// 增加相对位置的 z 坐标
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="deltaValue">z 坐标值</param>
        public static void AddLocalPositionZ(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.localPosition;
            v.z += deltaValue;
            transform.localPosition = v;
        }

        /// <summary>
        /// 设置相对尺寸的 x 分量
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="newValue">x 分量值</param>
        public static void SetLocalScaleX(this Transform transform, float newValue)
        {
            Vector3 v = transform.localScale;
            v.x = newValue;
            transform.localScale = v;
        }

        /// <summary>
        /// 设置相对尺寸的 y 分量
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="newValue">y 分量值</param>
        public static void SetLocalScaleY(this Transform transform, float newValue)
        {
            Vector3 v = transform.localScale;
            v.y = newValue;
            transform.localScale = v;
        }

        /// <summary>
        /// 设置相对尺寸的 z 分量
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="newValue">z 分量值</param>
        public static void SetLocalScaleZ(this Transform transform, float newValue)
        {
            Vector3 v = transform.localScale;
            v.z = newValue;
            transform.localScale = v;
        }

        /// <summary>
        /// 增加相对尺寸的 x 分量
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="deltaValue">x 分量增量</param>
        public static void AddLocalScaleX(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.localScale;
            v.x += deltaValue;
            transform.localScale = v;
        }

        /// <summary>
        /// 增加相对尺寸的 y 分量
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="deltaValue">y 分量增量</param>
        public static void AddLocalScaleY(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.localScale;
            v.y += deltaValue;
            transform.localScale = v;
        }

        /// <summary>
        /// 增加相对尺寸的 z 分量
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="deltaValue">z 分量增量</param>
        public static void AddLocalScaleZ(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.localScale;
            v.z += deltaValue;
            transform.localScale = v;
        }

        /// <summary>
        /// 二维空间下使 <see cref="UnityEngine.Transform" /> 指向指向目标点的算法，使用世界坐标
        /// </summary>
        /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象</param>
        /// <param name="lookAtPoint2D">要朝向的二维坐标点</param>
        /// <remarks>假定其 forward 向量为 <see cref="UnityEngine.Vector3.up" /></remarks>
        public static void LookAt2D(this Transform transform, Vector2 lookAtPoint2D)
        {
            Vector3 vector = lookAtPoint2D.ToVector3() - transform.position;
            vector.y = 0f;

            if (vector.magnitude > 0f) {
                transform.rotation = Quaternion.LookRotation(vector.normalized, Vector3.up);
            }
        }
    }
}
