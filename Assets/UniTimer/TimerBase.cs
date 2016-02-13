using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniTimer
{
    /// <summary>
    /// 回调函数委托
    /// </summary>
    /// <param name="time"></param>
    public delegate void TimerCallBack(float time);

    /// <summary>
    /// 计时器基类
    /// </summary>
    public class TimerBase
    {
        public virtual void Run(float time)
        {

        }
    }
}
