using UnityEngine;
using System.Collections;
using System;

public class ObjectGrabingV2OVR : ObjectGrabingV2
{
    [SerializeField]
    private TouchControllerBase Controller;

    protected override bool GrabTriggerPress()
    {
        return OVRInput.Get(OVRInput.RawButton.LHandTrigger, Controller.ControlIndex)
            || OVRInput.Get(OVRInput.RawButton.RHandTrigger, Controller.ControlIndex);
    }
    protected override bool GrabTriggerPressedDown()
    {
        return OVRInput.GetDown(OVRInput.RawButton.LHandTrigger, Controller.ControlIndex)
            || OVRInput.GetDown(OVRInput.RawButton.RHandTrigger, Controller.ControlIndex);
    }
}
