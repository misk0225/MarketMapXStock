using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiskCore.EventSender
{
    public class DOTweenEventElement : BaseEventElement
    {
        private Tween tween;
        private bool isFinish = false;

        public DOTweenEventElement(Tween tween)
        {
            this.tween = tween;
        }

        protected override void OnStart()
        {
            tween.onComplete = () => isFinish = true;
        }

        protected override void OnStop()
        {
            tween.Kill();
        }

        public override bool FinishCondition() => isFinish;
    }
}

