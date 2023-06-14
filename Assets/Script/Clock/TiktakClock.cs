using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiktakClock : ClockManager
{
    protected override void SetClock()
    {
        int hour = TransferHourToDegree();
        int minute = TransferMinuteToDegree();
        int second = TransferSecondToDegree();
        hourHand.rotation = Quaternion.Euler(0, 0, hour);
        minuteHand.rotation = Quaternion.Euler(0, 0, minute);
        secondHand.rotation = Quaternion.Euler(0, 0, second);
    }
}
