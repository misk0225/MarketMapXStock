using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;


namespace MiskCore.Playables.Behaviour
{
    public class IncrementBehaviour : PlayableBehaviour
    {
        private AnimationMixerPlayable mixer;
        private PlayableGraph graph;

        private List<Increment> increments = new List<Increment>();

        public void Init(PlayableGraph graph, Playable owner)
        {
            this.graph = graph;
            this.mixer = AnimationMixerPlayable.Create(graph);

            owner.SetInputCount(1);
            graph.Connect(mixer, 0, owner, 0);
        }

        public void UpdateWeight(float value)
        {
            value = Mathf.Clamp(value, increments[0].value, increments[increments.Count - 1].value);
            bool IsFindMin = false;

            for (int i = 0; i < increments.Count; i++)
            {
                Increment increment = increments[i];
                if (value > increment.value || IsFindMin)
                    mixer.SetInputWeight(i, 0);
                else
                {
                    if (i == 0)
                        mixer.SetInputWeight(0, 1);
                    else
                    {
                        float previousValue = increments[i - 1].value;
                        float weight = (value - previousValue) / (increment.value - previousValue);
                        mixer.SetInputWeight(i - 1, 1 - weight);
                        mixer.SetInputWeight(i, weight);
                    }


                    IsFindMin = true;
                }
            }
        }

        public void AddPlayable(Playable playable, float minValue)
        {
            for (int i = 0; i < increments.Count; i++)
            {
                if (minValue < increments[i].value)
                {
                    increments.Insert(i, new Increment(playable, minValue));
                    AddToMixer(playable, i);

                    return;
                }
            }

            increments.Add(new Increment(playable, minValue));
            AddToMixer(playable, mixer.GetInputCount());
        }

        private void AddToMixer(Playable playable, int index)
        {
            int count = mixer.GetInputCount();
            mixer.SetInputCount(count + 1);

            if (index >= count)
                graph.Connect(playable, 0, mixer, count);
            else
            {
                for (int i = count - 1; i < index; i++)
                {
                    var p = mixer.GetInput(i);
                    graph.Disconnect(mixer, i);
                    graph.Connect(p, 0, mixer, i + 1);
                }

                graph.Disconnect(mixer, index);
                graph.Connect(playable, 0, mixer, index);
            }
        }

    }


    public struct Increment
    {
        public Playable playable;
        public float value;

        public Increment(Playable Playable, float value)
        {
            this.playable = Playable;
            this.value = value;
        }
    }
}

