using UnityEngine;
using System.Collections;
 
public class ObjectGunOVR : ObjectGun, TouchVRInput
{
    private bool FireTrigger;
    private bool FireTriggerDown;

	private float LastLTriggerValue;
	private float LastRTriggerValue;

    protected override bool FireTriggerPress()
    {
        return FireTrigger;
    }
    protected override bool FireTriggerPressedDown()
    {
        return FireTriggerDown;
    }

	public void UpdateInput(OVRInput.Controller ctrlIndxe)
	{
		FireTrigger = OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger, ctrlIndxe) > 0.5f
			|| OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger, ctrlIndxe) > 0.5f;


		float lValue = OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger, ctrlIndxe);
		float rValue = OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger, ctrlIndxe);

		FireTriggerDown = (LastLTriggerValue < 0.5f && lValue >= 0.5f)
						|| (LastRTriggerValue < 0.5f && rValue >= 0.5f);

		LastLTriggerValue = lValue;
		LastRTriggerValue = rValue;
    }
}
