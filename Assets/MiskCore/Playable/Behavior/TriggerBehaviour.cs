using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;


namespace MiskCore.Playables.Behaviour
{
    public class TriggerBehaviour : PlayableBehaviour
    {

        private AnimationMixerPlayable mixer;
        private PlayableGraph graph;

        private Playable loopPlayable;
        private AnimationClipPlayable curClipPlayable;

        private float m_EnterSmoothTime;
        private float m_LeaveSmoothTime;
        private float m_LengthTime;
        private float m_CurTime;

        private List<Action> OnTriggerFinishs = new List<Action>();

        public void Init(PlayableGraph graph, Playable owner, Playable loopPlayable)
        {
            this.graph = graph;
            this.mixer = AnimationMixerPlayable.Create(graph);
            this.loopPlayable = loopPlayable;

            owner.SetInputCount(1);
            graph.Connect(mixer, 0, owner, 0);

            mixer.SetInputCount(2);
            graph.Connect(loopPlayable, 0, mixer, 0);
            mixer.SetInputWeight(0, 1);
        }

        public bool TrySwitchClipPlayable(AnimationClipPlayable playable, float enterSmoothTime = 0, float leaveSmoothTime = 0, Action OnFinish = null)
        {
            if (!curClipPlayable.IsNull() && curClipPlayable.IsValid()) return false;

            graph.Connect(playable, 0, mixer, 1);

            playable.SetTime(0);
            curClipPlayable = playable;
            m_EnterSmoothTime = enterSmoothTime;
            m_LengthTime = curClipPlayable.GetAnimationClip().length;
            m_LeaveSmoothTime = m_LengthTime - leaveSmoothTime;
            m_CurTime = 0;

            if (OnFinish != null)
                OnTriggerFinishs.Add(OnFinish);

            return true;
        }

        public void SetLoopPlayable(Playable playable)
        {
            graph.Disconnect(mixer, 0);
            graph.Connect(playable, 0, mixer, 0);
            loopPlayable = playable;
        }




        public override void PrepareFrame(Playable playable, FrameData info)
        {
            base.PrepareFrame(playable, info);
            if (curClipPlayable.IsNull() || !curClipPlayable.IsValid()) return;

            m_CurTime += info.deltaTime;
            UpdateTimeAndWeigth();

            if (m_CurTime >= m_LengthTime)
            {
                graph.Disconnect(mixer, 1);
                curClipPlayable.Destroy();

                if (OnTriggerFinishs.Count > 0)
                {
                    OnTriggerFinishs[0]?.Invoke();
                    OnTriggerFinishs.RemoveAt(0);
                }
            }
        }

        private void UpdateTimeAndWeigth()
        {
            float weight = 0;
            if (m_CurTime < m_EnterSmoothTime)
                weight = m_CurTime / m_EnterSmoothTime;
            else if (m_CurTime < m_LeaveSmoothTime)
                weight = 1;
            else if (m_CurTime < m_LengthTime)
                weight = 1 - (m_CurTime - m_LeaveSmoothTime) / (m_LengthTime - m_LeaveSmoothTime);
            else
                weight = 0;

            mixer.SetInputWeight(0, 1 - weight);
            mixer.SetInputWeight(1, weight);
        }
    }

}
