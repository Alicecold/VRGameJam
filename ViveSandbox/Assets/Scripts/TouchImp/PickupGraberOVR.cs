using UnityEngine;
using System.Collections;
using System;

public class PickupGraberOVR : PickupGraber
{
    [SerializeField]
    private TouchControllerBase Controller;

    protected override bool GrabTriggerPressedDown()
	{
		return OVRInput.GetDown(OVRInput.RawButton.LHandTrigger, Controller.ControlIndex)
			|| OVRInput.GetDown(OVRInput.RawButton.RHandTrigger, Controller.ControlIndex);
    }
    protected override bool GrabTriggerPressedUp()
	{
		return OVRInput.GetUp(OVRInput.RawButton.LHandTrigger, Controller.ControlIndex)
			|| OVRInput.GetUp(OVRInput.RawButton.RHandTrigger, Controller.ControlIndex);
    }
    protected override void UpdateObjectInput()
    {
		if (_State.PickupInHand is TouchVRInput)
			((TouchVRInput)_State.PickupInHand).UpdateInput(Controller.ControlIndex);
    }
}
