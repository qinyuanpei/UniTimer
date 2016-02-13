using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniTimer
{
    /// <summary>
    /// 一个倒计时的计时器
    /// 在到达指定时间前执行指定的回调事件
    /// </summary>
    public class TimerBefore:TimerBase
    {
        /// <summary>
        /// 当前时间
        /// </summary>
        private float currentTime = 0.0f;

        /// <summary>
        /// 延时时间
        /// </summary>
        private float delayTime = 0.0f;

        /// <summary>
        /// 回调函数
        /// </summary>
        private TimerCallBack callBack;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="currentTime">当前时间</param>
        /// <param name="delayTime">延迟时间</param>
        /// <param name="callBack">回调函数</param>
        public TimerBefore(float currentTime,float delayTime, TimerCallBack callBack)
        {
            this.currentTime = currentTime;
            this.delayTime = delayTime;
            this.callBack = callBack;
        }

        public override void Run(float time)
        {
            //计算时间差
            float offsetTime = time - currentTime;
            //到达时间后自动移除该计时器
            if(offsetTime >= delayTime){
                TimeManager.Get().RemoveTimer(this);
            }else{
                this.callBack(time);
            }  
        }
    }
}
