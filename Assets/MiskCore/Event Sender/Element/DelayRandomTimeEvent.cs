using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


namespace MiskCore.EventSender
{
    public class DelayRandomTimeEvent : BaseEventElement
    {
        protected float delayTime;

        protected bool isFinish = false;

        protected System.IDisposable observable;

        public DelayRandomTimeEvent(float min, float max)
        {
            delayTime = Random.Range(min, max);
        }

        public DelayRandomTimeEvent(int min, int max)
        {
            delayTime = Random.Range(min, max);
        }

        protected override void OnStart()
        {
            isFinish = false;
            observable = Observable.Timer(System.TimeSpan.FromSeconds(delayTime)).Subscribe((t) => isFinish = true);
        }

        protected override void OnStop()
        {
            observable.Dispose();
        }






        public override bool FinishCondition() => isFinish;

    }

}
