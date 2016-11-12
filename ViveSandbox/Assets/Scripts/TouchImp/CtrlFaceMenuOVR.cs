using UnityEngine;
using System.Collections;
using System;

public class CtrlFaceMenuOVR : CtrlFaceMenuSystem
{
    [SerializeField]
    private TouchControllerBase Controller;

    protected override bool FaceButtonPress()
	{
		return OVRInput.Get(OVRInput.RawButton.LThumbstick, Controller.ControlIndex)
			|| OVRInput.Get(OVRInput.RawButton.RThumbstick, Controller.ControlIndex);
    }
    protected override bool FaceButtonPressUp()
	{
		return OVRInput.GetUp(OVRInput.RawButton.LThumbstick, Controller.ControlIndex)
			|| OVRInput.GetUp(OVRInput.RawButton.RThumbstick, Controller.ControlIndex);
    }
    protected override bool FaceButtonsActive()
    {
		var value = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, Controller.ControlIndex) 
			+ OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, Controller.ControlIndex);
        return value.magnitude > 0.3f;

    }
    protected override Vector2 FaceButtonDirection()
    {
		return OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, Controller.ControlIndex) 
			+ OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, Controller.ControlIndex);
    }
    protected override void GiveButtonsActiveFeedback()
    {
    }
}
