using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiskCore.Process
{

    public class ActionOtherNambleQueue : ProcessComponent
    {
        [SerializeField]
        private NamableExecutQueueProcessComponent _Executer;

        [SerializeField]
        private string _ActionName;

        public override void OnProcessStart()
        {
            _Executer.Action(_ActionName);
            Finish();
        }
    }
}

