using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
public abstract class BasePlayableComponent : MonoBehaviour
{

    public PlayableGraph Graph { get; private set; }

    public PlayableOutput playableOutput { get; private set; }



    protected Animator _Animator;


    #region Unity EventCallback

    protected virtual void Awake()
    {
        _Animator = GetComponent<Animator>();
        Graph = PlayableGraph.Create();
        playableOutput = AnimationPlayableOutput.Create(Graph, "output", _Animator);
    }
    protected virtual void OnDestroy()
    {
        Graph.Destroy();
    }

    #endregion



    public abstract void Pause();

    public abstract void Continue();

}
