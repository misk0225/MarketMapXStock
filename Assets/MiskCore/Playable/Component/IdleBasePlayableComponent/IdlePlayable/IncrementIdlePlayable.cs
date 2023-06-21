using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using MiskCore.Playables.Behaviour;

namespace MiskCore.Playables.Module.IdleBase
{
    public class IncrementIdlePlayable : IIdlePlayable
    {
        public Playable Playable => IncrementPlayable;
        public IncrementBehaviour Behaviour { get; private set; }

        public ScriptPlayable<IncrementBehaviour> IncrementPlayable;


        public IncrementIdlePlayable(PlayableGraph graph)
        {
            IncrementPlayable = ScriptPlayable<IncrementBehaviour>.Create(graph);
            Behaviour = IncrementPlayable.GetBehaviour();
            Behaviour.Init(graph, IncrementPlayable);
        }
        public IncrementIdlePlayable(ScriptPlayable<IncrementBehaviour> incrementPlayable)
        {
            IncrementPlayable = incrementPlayable;
            Behaviour = IncrementPlayable.GetBehaviour();
        }
    }
}

