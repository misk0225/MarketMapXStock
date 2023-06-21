using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiskCore;

namespace MiskCore.Process
{
    /// <summary>
    /// 可自由掛載其他物建，並設定 Method
    /// 執行後立刻呼叫Finish
    /// </summary>
    public class ActionMethod : ProcessComponent
    {
        [SerializeField]
        private SequentialEventListeners _Methods;

        public override void OnProcessStart()
        {
            _Methods.Invoke();
            Finish();
        }
    }

}
