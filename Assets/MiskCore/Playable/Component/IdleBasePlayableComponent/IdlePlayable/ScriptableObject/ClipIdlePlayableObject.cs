using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace MiskCore.Playables.Module.IdleBase
{
    [CreateAssetMenu(fileName = "ClipIdlePlayable", menuName = "ScriptObjects/MiskCore/Playable/Module/IdleBase/Clip")]
    public class ClipIdlePlayableObject : ScriptableObject
    {
        [SerializeField]
        private AnimationClip _Clip;

        public IIdlePlayable GetIdle(PlayableGraph graph)
        {
            return new ClipIdlePlayable(graph, _Clip);
        }
    }
}

