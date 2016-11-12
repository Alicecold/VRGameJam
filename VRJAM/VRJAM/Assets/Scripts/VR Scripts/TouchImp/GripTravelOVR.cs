using UnityEngine;
using System.Collections;
using System;
using Valve.VR;

public class GripTravelOVR : GripTravel
{
    [SerializeField]
    private TouchControllerBase LeftController;
    [SerializeField]
    private TouchControllerBase RightController;
    [SerializeField]
	private OVRInput.RawButton LeftGripButton;
	[SerializeField]
	private OVRInput.RawButton RightGripButton;

    protected override bool LeftTriggerPress()
    {
        if (LeftController.ControlIndex < 0)
            return false;
		return OVRInput.Get(LeftGripButton, LeftController.ControlIndex);
    }
    protected override bool RightTriggerPress()
    {
		if (RightController.ControlIndex < 0)
			return false;
		return OVRInput.Get(RightGripButton, RightController.ControlIndex);
    }
}
