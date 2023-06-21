using UnityEngine.Animations;
using UnityEngine.Playables;


namespace MiskCore.Playables.Module.IdleBase
{
    /// <summary>
    /// 執行一次動畫接口
    /// 需提供動畫混合行為與呼叫結束時機
    /// </summary>
    public interface IActionOncePlayable
    {

        /// <summary>
        /// 開始混合時參與的 Playable
        /// </summary>
        public Playable StartMixPlayable { get; }

        /// <summary>
        /// 當開始進行
        /// </summary>
        public void OnStart(IdleBaseComponent component, AnimationMixerPlayable mixerPlayable);

        /// <summary>
        /// 進入混合 Update
        /// </summary>
        public void OnUpdate(float deltaTime);

        /// <summary>
        /// 呼叫結束動畫
        /// </summary>
        public bool ExitCondition();

        /// <summary>
        /// 當完全離開
        /// </summary>
        public void OnExit();

        /// <summary>
        /// 當行為被暫停
        /// </summary>
        public void OnPause();

        /// <summary>
        /// 當行為被通知繼續
        /// </summary>
        public void OnContinue();
    }
}
