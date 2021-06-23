// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: CounterFPS.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using UnityEngine;

namespace FrameworkUnityPlugin
{
    public class CounterFPS : MonoBehaviour
    {
        private static string s_FpsFormat = "fps:{0} ms:{1}";
        private static Rect s_FpsRect = new Rect(0, 200, 200, 100);
        private static GUIStyle s_GuiStyle = new GUIStyle();

        public enum Ancher
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
        }

        [SerializeField]
        private Ancher m_Poivt = Ancher.BottomRight;
        [SerializeField]
        private float m_Interval = 1f;

        private float m_LastInterval;
        private int m_Frame = 0;
        private float m_FPS;

        private void Start()
        {
            m_Frame = 0;
            m_LastInterval = Time.realtimeSinceStartup;
        }

        private void Update()
        {
            ++m_Frame;
            if (Time.realtimeSinceStartup > m_LastInterval + m_Interval) {
                m_FPS = m_Frame / (Time.realtimeSinceStartup - m_LastInterval);
                m_Frame = 0;
                m_LastInterval = Time.realtimeSinceStartup;
            }
        }

        private void OnGUI()
        {
            switch (m_Poivt) {
                case Ancher.BottomLeft:
                    s_FpsRect.Set(0, Screen.height - 20, 200, 100);
                    break;
                case Ancher.BottomRight:
                    s_FpsRect.Set(Screen.width - 160, Screen.height - 20, 400, 200);
                    break;
                case Ancher.TopLeft:
                    s_FpsRect.Set(0, 0, 200, 100);
                    break;
                case Ancher.TopRight:
                    s_FpsRect.Set(Screen.width - 160, 0, 200, 100);
                    break;
            }

            s_GuiStyle.fontSize = 20;
            s_GuiStyle.normal.textColor = Color.white;

            GUI.Label(s_FpsRect,
                string.Format(s_FpsFormat, m_FPS.ToString("f2"),
                (1000.0f / Mathf.Max(m_FPS, 0.001f)).ToString("f1")),
                s_GuiStyle
            );
        }
    }
}
