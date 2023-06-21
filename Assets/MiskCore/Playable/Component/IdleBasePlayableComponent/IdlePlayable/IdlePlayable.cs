using UnityEngine.Playables;


namespace MiskCore.Playables.Module.IdleBase
{
    /// <summary>
    /// 待機的 Playable 接口
    /// </summary>
    public interface IIdlePlayable
    {
        /// <summary>
        /// 主要的待機 Playable
        /// 必須是 Loop 狀態
        /// </summary>
        public Playable Playable { get; }

    }

}

