using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiskCore.Process
{
    /// <summary>
    /// 用Queue概念執行Process類別
    /// 放在Process們的父物件上，會自動抓取Process
    /// </summary>
    public class QueueProcessComponent : ProcessComponent
    {

        private List<ProcessComponent> m_Processs = new List<ProcessComponent>();

        private int m_CurIndex = -1;

        public override void OnAwake()
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                var p = transform.GetChild(i).GetComponent<ProcessComponent>();
                m_Processs.Add(p);
            }
        }

        public override void OnProcessStart()
        {
            OnProcessFroceStop();

            m_CurIndex = 0;
            m_Processs[m_CurIndex].onFinish += RecursionCallNextOnFinish;
            m_Processs[m_CurIndex].Action();
        }

        public override void OnProcessFroceStop()
        {
            if (m_CurIndex != -1)
            {
                m_Processs[m_CurIndex].onFinish -= RecursionCallNextOnFinish;
                m_Processs[m_CurIndex].OnProcessFroceStop();
                m_CurIndex = -1;
            }
        }

        private void RecursionCallNextOnFinish()
        {
            m_Processs[m_CurIndex].onFinish -= RecursionCallNextOnFinish;

            m_CurIndex ++;
            if (m_CurIndex < m_Processs.Count)
            {
                m_Processs[m_CurIndex].onFinish += RecursionCallNextOnFinish;
                m_Processs[m_CurIndex].Action();
            }
            else
            {
                m_CurIndex = -1;
                Finish();
            }
        }
    }
}

