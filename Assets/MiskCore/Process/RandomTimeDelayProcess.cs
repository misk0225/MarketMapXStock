using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


namespace MiskCore.Process
{
    public class RandomTimeDelayProcess : ProcessComponent
    {
        [SerializeField]
        private float _MinTime;

        [SerializeField]
        private float _MaxTime;

        private IDisposable _Timing;

        public override void OnProcessStart()
        {
            _Timing = Observable.Timer(TimeSpan.FromSeconds(UnityEngine.Random.Range(_MinTime, _MaxTime))).Subscribe((_) => Finish()).AddTo(this);
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

