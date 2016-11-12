using UnityEngine;
using System.Collections;

public class TeleporterOVR : Teleporter
{
    [SerializeField]
    private TouchControllerBase Controller;

    protected override bool HUDButtonPress()
	{
		return OVRInput.Get(OVRInput.RawButton.A, Controller.ControlIndex)
			|| OVRInput.Get(OVRInput.RawButton.X, Controller.ControlIndex);
    }
    protected override bool TeleportPressedDown()
	{
		return OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger, Controller.ControlIndex) > 0.5f
			|| OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger, Controller.ControlIndex) > 0.5f;
    }
}
