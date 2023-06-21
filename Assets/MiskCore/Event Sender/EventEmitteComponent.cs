using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiskCore.EventSender
{
    public class EventEmitteComponent : MonoBehaviour
    {
        private HashSet<BaseEventElement> events = new HashSet<BaseEventElement>();
        private List<BaseEventElement> _removeResigter = new List<BaseEventElement>();

        private void Awake()
        {

        }

        private void Update()
        {
            _removeResigter.Clear();

            foreach (var e in events)
            {
                if (e.FinishCondition())
                {
                    e.Finish();
                    _removeResigter.Add(e);
                }
                else
                {
                    e.Update();
                }
            }

            foreach (var e in _removeResigter)
            {
                events.Remove(e);
            }
        }

        private void OnDestroy()
        {
            foreach (var e in events)
            {
                e.Stop();
            }

            events.Clear();
        }

        public void Emitte(BaseEventElement e)
        {
            events.Add(e);
            e.Start();
        }

        public void Remove(BaseEventElement e)
        {
            e.Stop();
            events.Remove(e);
        }

        public bool TryRemove(BaseEventElement e)
        {
            if (events.Contains(e))
            {
                Remove(e);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

