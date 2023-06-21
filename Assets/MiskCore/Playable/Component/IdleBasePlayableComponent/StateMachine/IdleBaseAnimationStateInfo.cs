using MiskCore.Playables.Module.IdleBase;
using UnityEngine;
using UnityEngine.Playables;

namespace MiskCore.Playables.Module.IdleBase.StateMachine
{
    public interface IIdleBaseStateInfo
    {

        /// <summary>
        /// 此狀態的待機狀態
        /// </summary>
        public IIdlePlayable IdlePlayable { get; }

        /// <summary>
        /// 進入狀態時的 Playable
        /// </summary>
        public Playable StartPlayable { get; }

        /// <summary>
        /// 離開狀態時的 Playable
        /// </summary>
        public Playable ExitPlayable { get; }
    }

}

