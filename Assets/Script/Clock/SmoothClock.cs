using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothClock : ClockManager
{
    
    protected override void SetClock()
    {
        int hour = TransferHourToDegree();
        int minute = TransferMinuteToDegree();
        int second = TransferSecondToDegree();
        Quaternion currentSecondQuaterion = Quaternion.Euler(0, 0, second);
        Quaternion currentMinuteQuaterion = Quaternion.Euler(0, 0, minute);
        Quaternion nextSecondQuaterion = Quaternion.Euler(0, 0, second + MINUTEANDSECONDDEGREETWIST);
        Quaternion nextMinuteQuaterion = Quaternion.Euler(0, 0, minute + MINUTEANDSECONDDEGREETWIST);
        hourHand.rotation = Quaternion.Euler(0, 0, hour);
        minuteHand.rotation = Quaternion.Slerp(minuteHand.rotation, currentMinuteQuaterion, 1 * Time.deltaTime);
        secondHand.rotation = Quaternion.Slerp(secondHand.rotation, currentSecondQuaterion, 1 * Time.deltaTime);
    }
}
