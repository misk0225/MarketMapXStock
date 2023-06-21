using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


namespace MiskCore.Process
{
    public class TimeDelayProcess : ProcessComponent
    {
        [SerializeField]
        private float _Time;

        private IDisposable _Timing;

        public override void OnProcessStart()
        {
            _Timing = Observable.Timer(TimeSpan.FromSeconds(_Time)).Subscribe((_) => Finish()).AddTo(this);
        }

        public override void OnProcessFroceStop()
        {
            _Timing?.Dispose();
        }

        public override void OnProcessFinish()
        {
            _Timing?.Dispose();
        }
    }
}

