using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiskCore.EventSender
{
    public class EventIteratorElement : BaseEventElement
    {
        private BaseEventElement[] events;
        private int maxEventCount;
        private int curEventIdx;


        public EventIteratorElement(BaseEventElement[] events)
        {
            this.events = events;
            this.maxEventCount = events.Length;
        }


        protected override void OnStart()
        {
            this.curEventIdx = 0;
            this.events[0].Start();
        }

        protected override void OnUpdate()
        {
            if (curEventIdx == this.events.Length)
                return;

            this.events[curEventIdx].Update();

            while (this.events[curEventIdx].FinishCondition())
            {
                this.events[curEventIdx].Finish();
                curEventIdx++;

                if (curEventIdx < this.events.Length)
                {
                    this.events[curEventIdx].Start();
                }
                else
                {
                    break;
                }
            }
        }

        protected override void OnStop()
        {
            if (curEventIdx < this.events.Length)
            {
                this.events[curEventIdx].Stop();
            }
        }


        public override bool FinishCondition() => maxEventCount == curEventIdx;
    }
}

