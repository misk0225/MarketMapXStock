using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiskCore.EventSender
{
    public class CallBackEventElement : BaseEventElement
    {
        Action callback;
        public CallBackEventElement(Action action) => callback = action;

        protected override void OnStart() => callback();

        public override bool FinishCondition() => true;
    }
}

