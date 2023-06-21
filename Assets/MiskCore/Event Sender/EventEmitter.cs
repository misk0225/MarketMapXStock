using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiskCore.EventSender
{
    public static class EventEmitter
    {
        private static EventEmitteComponent emitter
        {
            get
            {
                if (_component == null)
                {
                    GameObject o = new GameObject("EventSender.Emitter");
                    _component = o.AddComponent<EventEmitteComponent>();
                }

                return _component;
            }
        }
        private static EventEmitteComponent _component;

        public static void Do(BaseEventElement e)
        {
            emitter.Emitte(e);
        }

        public static void Remove(BaseEventElement e)
        {
            emitter.Remove(e);
        }

        public static bool TryRemove(BaseEventElement e)
        {
            return emitter.TryRemove(e);
        }
    }
}

