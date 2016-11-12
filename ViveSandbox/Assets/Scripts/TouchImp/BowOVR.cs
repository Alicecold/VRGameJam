using UnityEngine;
using System.Collections;

public class BowOVR : Bow
{
    protected override void TenseningFeedback(int durationMS)
    {
		var gripper = TenseningGrip.GetComponent<TouchControllerBase>();
		gripper.HapticPulse(100, (byte)durationMS);
    }
}
