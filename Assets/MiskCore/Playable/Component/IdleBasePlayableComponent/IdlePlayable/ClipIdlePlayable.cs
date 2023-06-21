using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;


namespace MiskCore.Playables.Module.IdleBase
{
    /// <summary>
    /// 用一個 clip 當作待機動畫
    /// </summary>
    public struct ClipIdlePlayable : IIdlePlayable
    {
        public Playable Playable { get; private set; }

        public ClipIdlePlayable(PlayableGraph graph, AnimationClip clip)
        {
            Playable = AnimationClipPlayable.Create(graph, clip);
        }
    }

}
