using System;


namespace MiskCore.EventSender
{
    public abstract class BaseEventElement
    {
        private Action onComplete = null;

        public BaseEventElement OnComplete(Action onComplete)
        {
            this.onComplete = onComplete;
            return this;
        }

        protected virtual void OnStart() { }

        protected virtual void OnUpdate() { }

        protected virtual void OnFinish() { }

        protected virtual void OnStop() { }

        public void Start()
        {
            OnStart();
        }

        public void Update()
        {
            OnUpdate();
        }

        public void Finish()
        {
            OnStop();
            OnFinish();
            onComplete?.Invoke();
        }

        public void Stop()
        {
            OnStop();
        }

        public abstract bool FinishCondition();
    }
}

