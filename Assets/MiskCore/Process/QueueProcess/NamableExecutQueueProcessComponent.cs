using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiskCore.Process
{
    public class NamableExecutQueueProcessComponent : MonoBehaviour
    {
        private Dictionary<string, QueueProcessExcuterRootComponent> m_ExecuterMap = new Dictionary<string, QueueProcessExcuterRootComponent>();

        private void Awake()
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                var t = transform.GetChild(i);
                m_ExecuterMap.Add(t.name, t.GetComponent<QueueProcessExcuterRootComponent>());
            }
        }

        public void Action(string name)
        {
            m_ExecuterMap[name].Action();
        }

        public void ForceStop(string name)
        {
            m_ExecuterMap[name].FroceStop();
        }
    }
}

