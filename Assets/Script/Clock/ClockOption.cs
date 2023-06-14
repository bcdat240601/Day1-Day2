using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockOption : SetupBehaviour
{
    [SerializeField] protected TiktakClock tiktakClock;
    [SerializeField] protected SmoothClock smoothClock;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetTiktokClock();
        GetSmoothClock();
    }

    protected virtual void GetSmoothClock()
    {
        if (smoothClock != null) return;
        smoothClock = GetComponentInChildren<SmoothClock>();
        Debug.Log("Reset " + nameof(smoothClock) + " in " + GetType().Name);
    }

    protected virtual void GetTiktokClock()
    {
        if (tiktakClock != null) return;
        tiktakClock = GetComponentInChildren<TiktakClock>();
        Debug.Log("Reset " + nameof(tiktakClock) + " in " + GetType().Name);
    }
    protected override void Awake()
    {
        base.Awake();
        TiktakMode();
    }
    public virtual void TiktakMode()
    {
        tiktakClock.enabled = true;
        smoothClock.enabled = false;
    }
    public virtual void SmoothMode()
    {
        tiktakClock.enabled = false;
        smoothClock.enabled = true;
    }
}
