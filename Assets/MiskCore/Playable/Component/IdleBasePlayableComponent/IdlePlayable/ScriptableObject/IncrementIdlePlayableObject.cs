using MiskCore.Playables.Behaviour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace MiskCore.Playables.Module.IdleBase
{
    [CreateAssetMenu(fileName = "IncrementIdlePlayable", menuName = "ScriptObjects/MiskCore/Playable/Module/IdleBase/Increment")]
    public class IncrementIdlePlayableObject : ScriptableObject
    {
        [SerializeField]
        private List<AnimationClip> _Clips;

        [SerializeField]
        private List<float> _Values;

        public IncrementIdlePlayable GetIncrementIdle(PlayableGraph graph)
        {
            IncrementIdlePlayable incrementIdlePlayable = new IncrementIdlePlayable(graph);

            for (int i = 0; i < _Clips.Count; ++i)
            {
                incrementIdlePlayable.Behaviour.AddPlayable(AnimationClipPlayable.Create(graph, _Clips[i]), _Values[i]);
            }

            return incrementIdlePlayable;
        }
    }
}

