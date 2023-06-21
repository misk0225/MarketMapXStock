using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiskCore.EventSender
{
    public class ArgInputEventElement : BaseEventElement
    {
        private Action onStart = () => { };
        private Action onUpdate = () => { };
        private Action onFinish = () => { };
        private Action onStop = () => { };
        private Func<bool> condition;

        public ArgInputEventElement(Func<bool> condition, Action onStart = null, Action onUpdate = null, Action onFinish = null, Action onStop = null)
        {
            if (onStart != null) this.onStart = onStart;
            if (onUpdate != null) this.onUpdate = onUpdate;
            if (onFinish != null) this.onFinish = onFinish;
            if (onStop != null) this.onStop = onStop;
            this.condition = condition;
        }

        protected override void OnStart() => onStart();
        protected override void OnUpdate() => onUpdate();
        protected override void OnFinish() => onFinish();
        protected override void OnStop() => onStop();

        public override bool FinishCondition() => condition();

    }
}

