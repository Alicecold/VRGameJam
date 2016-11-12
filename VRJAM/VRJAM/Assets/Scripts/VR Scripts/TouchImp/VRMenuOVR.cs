using UnityEngine;
using System.Collections;

public class VRMenuOVR : VRMenuSystem
{
    [SerializeField]
    protected TouchControllerBase MenuController;
    [SerializeField]
    protected TouchControllerBase PointerController;

	private float LastLTriggerValue;
	private float LastRTriggerValue;

    protected override bool MenuTriggerPress()
	{
		return OVRInput.Get(OVRInput.RawButton.LHandTrigger, MenuController.ControlIndex)
			|| OVRInput.Get(OVRInput.RawButton.RHandTrigger, MenuController.ControlIndex);
    }
    protected override bool MenuTriggerPressedDown()
	{
		return OVRInput.GetDown(OVRInput.RawButton.LHandTrigger, MenuController.ControlIndex)
			|| OVRInput.GetDown(OVRInput.RawButton.RHandTrigger, MenuController.ControlIndex);
    }
    protected override bool MenuClickPressedDown()
    {
		float lValue = OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger, PointerController.ControlIndex);
		float rValue = OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger, PointerController.ControlIndex);

		bool result = (LastLTriggerValue < 0.5f && lValue >= 0.5f)
			|| (LastRTriggerValue < 0.5f && rValue >= 0.5f);

		LastLTriggerValue = lValue;
		LastRTriggerValue = rValue;

		return result;
	}
    protected override void GiveMenuOpenFeedback()
    {
		MenuController.HapticPulse (500, 128);
    }
}
