using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace MiskCore
{
    [Serializable]
    public class SequentialEventListeners
    {
        [SerializeField]
        private List<UnityEvent> m_Functions;
        
        public void Invoke()
        {
            for (int i = 0; i < m_Functions.Count; ++i)
            {
                m_Functions[i].Invoke();
            }
        }
    }

    [Serializable]
    public class SequentialEventListeners<T1>
    {
        [SerializeField]
        private List<UnityEvent<T1>> m_Functions;

        public void Invoke(T1 a1)
        {
            for (int i = 0; i < m_Functions.Count; ++i)
            {
                m_Functions[i].Invoke(a1);
            }
        }
    }


    [Serializable]
    public class SequentialEventListeners<T1, T2>
    {
        [SerializeField]
        private List<UnityEvent<T1, T2>> m_Functions;

        public void Invoke(T1 a1, T2 a2)
        {
            for (int i = 0; i < m_Functions.Count; ++i)
            {
                m_Functions[i].Invoke(a1, a2);
            }
        }
    }


    [Serializable]
    public class SequentialEventListeners<T1, T2, T3>
    {
        [SerializeField]
        private List<UnityEvent<T1, T2, T3>> m_Functions;

        public void Invoke(T1 a1, T2 a2, T3 a3)
        {
            for (int i = 0; i < m_Functions.Count; ++i)
            {
                m_Functions[i].Invoke(a1, a2, a3);
            }
        }
    }


    [Serializable]
    public class SequentialEventListeners<T1, T2, T3, T4>
    {
        [SerializeField]
        private List<UnityEvent<T1, T2, T3, T4>> m_Functions;

        public void Invoke(T1 a1, T2 a2, T3 a3, T4 a4)
        {
            for (int i = 0; i < m_Functions.Count; ++i)
            {
                m_Functions[i].Invoke(a1, a2, a3, a4);
            }
        }
    }
}

