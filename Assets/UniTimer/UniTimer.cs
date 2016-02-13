using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UniTimer
{
    public class TimeManager : MonoBehaviour
    {
        /// <summary>
        /// 时间管理器单例
        /// </summary>
        private static TimeManager instance = null;
        public static TimeManager Get()
        {
            if(instance == null){
                GameObject go = new GameObject("TimeManager");
                instance = go.AddComponent<TimeManager>();
            }
            return instance;
        }

        /// <summary>
        /// 运行中的Timer列表
        /// </summary>
        private List<TimerBase> runLists = new List<TimerBase>();

        /// <summary>
        /// 被停止的Timer列表
        /// </summary>
        private List<TimerBase> stopLists = new List<TimerBase>();

        /// <summary>
        /// 注册Timer
        /// </summary>
        /// <param name="timer">Timer</param>
        public void RegisterTimer(TimerBase timer)
        {
            if(runLists == null)
                return;
            runLists.Add(timer);
        }

        /// <summary>
        /// 移除Timer
        /// </summary>
        /// <param name="timer">Timer</param>
        public void RemoveTimer(TimerBase timer)
        {
            if(!runLists.Contains(timer))
                return;
            runLists.Remove(timer);
        }

        /// <summary>
        /// 执行时间管理器的每一个Timer
        /// </summary>
        private void RunTimers()
        {
            //复制一份Timer列表
            TimerBase[] timers = new TimerBase[runLists.Count];
            runLists.CopyTo(timers);

            if(timers.Length <= 0)
                return;

            //执行每一个Timer
            foreach(TimerBase timer in timers)
            {
                timer.Run(Time.time);
            }
        }

        /// <summary>
        /// 停止指定计时器
        /// </summary>
        /// <param name="timer"></param>
        public void StopTimer(TimerBase timer)
        {
            if(!runLists.Contains(timer))
                return;

            runLists.Remove(timer);
            stopLists.Add(timer);
        }

        /// <summary>
        /// 恢复指定计时器
        /// </summary>
        /// <param name="timer"></param>
        public void ResumeTimer(TimerBase timer)
        {
            if(!stopLists.Contains(timer))
                return;

            stopLists.Remove(timer);
            runLists.Add(timer);
        }

        void Update()
        {
            RunTimers();
        }
    }
}