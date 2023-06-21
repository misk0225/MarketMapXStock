using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiskCore.Process
{
    /// <summary>
    /// Process Component 是一個廣泛的，概括卻獨立的流程元件，在執行時 GameObject 會亮起，也就是說擁有清楚的介面可看出正在執行的流程
    /// 以 State Machine 模式執行程式，等於是物件式、可序列化、可顯示的 State Machine
    /// </summary>
    public abstract class ProcessComponent : MonoBehaviour
    {
        public Action onStart;
        public Action onFinish;

        public void Action()
        {
            gameObject.SetActive(true);
            OnProcessStart();
            onStart?.Invoke();
        }

        public void Finish()
        {
            OnProcessFinish();
            gameObject.SetActive(false);
            onFinish?.Invoke();
        }

        public abstract void OnProcessStart();

        public virtual void OnAwake() { }

        public virtual void OnStart() { }

        public virtual void OnActionUpdate() { }

        public virtual void OnUpdate() { }

        public virtual void OnActionFixUpdate() { }

        public virtual void OnFixUpdate() { }

        public virtual void OnProcessFinish() { }

        public virtual void OnProcessFroceStop() { }



        #region Unity Event

        private void Awake() 
        {
            OnAwake();
        }

        private void Start() 
        {
            OnStart();
            gameObject.SetActive(false);
        }

        private void Update()
        {
            OnUpdate();
            if (gameObject.activeSelf)
                OnActionUpdate();
        }

        private void FixedUpdate()
        {
            OnFixUpdate();
            if (gameObject.activeSelf)
                OnActionFixUpdate();
        }

        #endregion
    }
}

