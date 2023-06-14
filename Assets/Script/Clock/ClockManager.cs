using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClockManager : SetupBehaviour
{
    [SerializeField] protected Transform hourHand;
    [SerializeField] protected Transform minuteHand;
    [SerializeField] protected Transform secondHand;
    protected const int HOURDEGREETWIST = 30;
    protected const int MINUTEANDSECONDDEGREETWIST = 6;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetHourHand();
        GetMinuteHand();
        GetSecondHand();
    }

    protected virtual void GetHourHand()
    {
        if (hourHand != null) return;
        hourHand = transform.Find("HourHandTwist");
        Debug.Log("Reset " + nameof(hourHand) + " in " + GetType().Name);
    }
    protected virtual void GetMinuteHand()
    {
        if (minuteHand != null) return;
        minuteHand = transform.Find("MinuteHandTwist");
        Debug.Log("Reset " + nameof(hourHand) + " in " + GetType().Name);
    }
    protected virtual void GetSecondHand()
    {
        if (secondHand != null) return;
        secondHand = transform.Find("SecondHandTwist");
        Debug.Log("Reset " + nameof(hourHand) + " in " + GetType().Name);
    }

    protected virtual DateTime GetCurrentTime()
    {
        DateTime currentTime = DateTime.Now;
        return currentTime;
    }
    protected virtual void Update()
    {
        SetClock();
    }

    protected virtual int TransferHourToDegree()
    {
        DateTime currentTime = GetCurrentTime();
        int hour = currentTime.Hour;
        if (hour >= 12)
            hour -= 12;
        int degree = hour * HOURDEGREETWIST;
        int minute = currentTime.Minute;
        int hourOffset = minute / 12;
        degree += hourOffset * MINUTEANDSECONDDEGREETWIST;        
        return -degree;
    }
    protected virtual int TransferMinuteToDegree()
    {
        DateTime currentTime = GetCurrentTime();
        int minute = currentTime.Minute;
        int degree = minute * MINUTEANDSECONDDEGREETWIST;
        return -degree;
    }
    protected virtual int TransferSecondToDegree()
    {
        DateTime currentTime = GetCurrentTime();
        int second = currentTime.Second;
        int degree = second * MINUTEANDSECONDDEGREETWIST;
        return -degree;
    }
    protected abstract void SetClock();
}
