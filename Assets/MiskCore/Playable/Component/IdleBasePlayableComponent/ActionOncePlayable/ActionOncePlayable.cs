using System;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace MiskCore.Playables.Module.IdleBase
{
    public class ActionOncePlayable : IActionOncePlayable
    {
        public Playable StartMixPlayable { get; private set; }

        private float _StartMixTime;
        private float _ExitMixTime;
        private float _CurTime;
        private float _MaxTime;
        private AnimationMixerPlayable _Mixer;
        private bool _Continue = true;

        private Action<float> _UpdateEvent;

        public ActionOncePlayable(Playable playable, float startMixTime, float exitMixTime)
        {
            StartMixPlayable = playable;
            _StartMixTime = startMixTime;
            _ExitMixTime = exitMixTime;
            _MaxTime = (float)playable.GetDuration();
        }

        public void OnStart(IdleBaseComponent component, AnimationMixerPlayable mixerPlayable)
        {
            _Mixer = mixerPlayable;
            _CurTime = 0;

            StartMixPlayable.SetTime(0.1f);

            StartMix();
        }

        public bool ExitCondition()
        {
            return StartMixPlayable.GetTime() >= _MaxTime;
        }

        public void OnUpdate(float deltaTime)
        {
            if (!_Continue) return;

            _CurTime += deltaTime;
            _UpdateEvent?.Invoke(deltaTime);
        }

        public void OnExit()
        {
            _UpdateEvent = null;
            _Mixer.GetGraph().Disconnect(_Mixer, 1);
            _Mixer.SetInputWeight(0, 1);
            _Mixer.SetInputWeight(1, 0);
        }


        private void StartMix()
        {
            Action<float> update = (t) => { };
            update = (t) => {
                if (_CurTime >= _StartMixTime)
                {
                    _Mixer.SetInputWeight(0, 0);
                    _Mixer.SetInputWeight(1, 1);
                    _UpdateEvent -= update;
                    ExitMix();
                }
                else
                {
                    float weight = _CurTime / _StartMixTime;
                    _Mixer.SetInputWeight(0, 1 - weight);
                    _Mixer.SetInputWeight(1, weight);
                }
            };

            _UpdateEvent += update;
        }

        private void ExitMix()
        {
            Action<float> update = (t) => { };
            update = (t) =>
            {
                if (_CurTime >= _MaxTime)
                {
                    _UpdateEvent -= update;
                }
                else if (_CurTime >= _MaxTime - _ExitMixTime)
                {
                    float weight = 1 - (_MaxTime - _CurTime) / _ExitMixTime;
                    _Mixer.SetInputWeight(0, weight);
                    _Mixer.SetInputWeight(1, 1 - weight);
                }
            };

            _UpdateEvent += update;
        }

        public void OnPause()
        {
            _Continue = false;
        }

        public void OnContinue()
        {
            _Continue = true;
        }
    }
}

