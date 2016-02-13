using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniTimer
{   
    /// <summary>
    /// 一个重复执行的计时器
    /// 每隔一段时间执行指定的回调函数
    /// </summary>
    public class TimerRepeat:TimerBase
    {
        /// <summary>
        /// 当前时间
        /// </summary>
        private float currentTime = 0.0f;

        /// <summary>
        /// 间隔时间
        /// </summary>
        private float interval = 0.0f;

        /// <summary>
        /// 回调函数
        /// </summary>
        private TimerCallBack callBack;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="currentTime"></param>
        /// <param name="interval"></param>
        /// <param name="callBack"></param>
        public TimerRepeat(float currentTime, float interval, TimerCallBack callBack)
        {
            this.currentTime = currentTime;
            this.interval = interval;
            this.callBack = callBack;
        }

        public override void Run(float time)
        {
            //计算时间差
            float offsetTime = time - currentTime;
            //到达时间间隔后执行回调函数然后重置时间
            if(offsetTime >= interval)
            {
                this.callBack(time);
                this.currentTime = time - offsetTime % interval;
            }
        }
    }
}
