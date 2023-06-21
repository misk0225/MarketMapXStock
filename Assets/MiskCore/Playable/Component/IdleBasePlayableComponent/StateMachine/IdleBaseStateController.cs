using MiskCore.Playables.Module.IdleBase;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


namespace MiskCore.Playables.Module.IdleBase.StateMachine
{
    public class IdleBaseStateController
    {
        public IIdleBaseStateInfo CurState { get; protected set; }

        private IIdlePlayable _RootIdlePlayable;

        private IdleBaseComponent _Component;


        public IdleBaseStateController(IdleBaseComponent component)
        {
            _Component = component;
        }
        public IdleBaseStateController(IdleBaseComponent component, IIdlePlayable root) : this (component)
        {
            SetRoot(root);
        }



        public void SetRoot(IIdlePlayable root)
        {
            _RootIdlePlayable = root;
            _Component.SetIdlePlayable(root);
        }

        public void ResetToRoot(float mixTime, Action OnFinish = null)
        {
            if (CurState == null) return;

            _Component.ActionOnceAnimation(new ActionOncePlayable(CurState.ExitPlayable, mixTime, 0), () =>
            {
                OnFinish?.Invoke();
            });

            CurState = null;
        }

        public void SwitchState(IIdleBaseStateInfo state, float mixTime = 0, Action OnFinish = null)
        {
            if (CurState != null)
                _Component.ActionOnceAnimation(new ActionOncePlayable(CurState.ExitPlayable, mixTime, 0), () => SetNextStateAndTransition(state));
            else
                SetNextStateAndTransition(state, OnFinish);
        }




        private void SetNextStateAndTransition(IIdleBaseStateInfo state, Action OnFinish = null)
        {
            CurState = state;
            _Component.ActionOnceAnimation(new ActionOncePlayable(CurState.StartPlayable, 0, 0), () => {
                _Component.SetIdlePlayable(CurState.IdlePlayable);
                OnFinish?.Invoke();
            });
        }

    }

}
