using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class StaticTicker
{
    static Timer timer;
    static TimeSpan startTimeSpan = TimeSpan.Zero;
    static TimeSpan periodTimeSpan = TimeSpan.FromSeconds(1);
    static List<Action> registeredActions = new List<Action>();
    static public int tickCount;

    // Start is called before the first frame update
    public static void StartTick()
    {
        timer = new Timer((e) =>
        {
            Tick();
        }, null, startTimeSpan, periodTimeSpan);
    }

    public static void StopTick()
    {
        timer.Dispose();
    }

    static private void Tick()
    {
        tickCount++;
        Debug.Log("Tick "+tickCount);
        foreach (var action in registeredActions)
        {
            action.Invoke();
        }
        if (tickCount == 60)
        { 
            tickCount = 0;
        }
    }

    static public void Register(Action action)
    {
        registeredActions.Add(action);
    }
}
