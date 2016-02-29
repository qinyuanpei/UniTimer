# UniTimer
一个为Unity3D编写的简单的时间管理器，提供了延迟（TimerAfter）、前置（TimerBefore）、重复（TimerRepeat）三种Timer。

# 代码示例
```
using UnityEngine;
using System.Collections;
using UniTimer;

public class Example : MonoBehaviour {

	
	void Start () 
    {
        //在2.5s后触发一个事件然后销毁自身
        TimeManager.Get().RegisterTimer(
            new TimerAfter(Time.time, 2.5f, (t)=>{ Debug.Log("时间到!"); }));

        //在时间到达10s前显示一个倒计时时间到达后销毁自身
        TimeManager.Get().RegisterTimer(
            new TimerBefore(Time.time, 10f, (t)=> { Debug.Log("距离10s还有"+ (10-t) + "s"); }));

        //每隔2.5s触发一个事件
        TimeManager.Get().RegisterTimer(
            new TimerRepeat(Time.time, 2.5f, (time) => { Debug.Log("我每隔2.5s触发一次"); }));

        //在2.5s后每隔10s触发一个事件
        TimeManager.Get().RegisterTimer(
            new TimerAfter(Time.time, 2.5f, (t) =>
            {
                TimeManager.Get().RegisterTimer(
                    new TimerRepeat(t, 10f, (time) => { Debug.Log("这是一个混合使用Timer的例子"); }));
            }));
	}



}

```
