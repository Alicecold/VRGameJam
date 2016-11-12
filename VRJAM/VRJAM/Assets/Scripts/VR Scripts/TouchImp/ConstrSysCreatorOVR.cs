using UnityEngine;
using System.Collections;

public class ConstrSysCreatorOVR : ConstraintSysCreator
{
    [SerializeField]
    private TouchControllerBase Controller;
    
    protected override bool PlaceObject()
	{
		return OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger, Controller.ControlIndex) > 0.5f
			|| OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger, Controller.ControlIndex) > 0.5f;
    }
    protected override bool AttachFirst()
	{
		return OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger, Controller.ControlIndex) > 0.5f
			|| OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger, Controller.ControlIndex) > 0.5f;
    }
    protected override bool AttachSecond()
	{
		return OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger, Controller.ControlIndex) < 0.5f
			|| OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger, Controller.ControlIndex) < 0.5f;
    }
    protected override bool GrabbingObject()
	{
		return OVRInput.Get(OVRInput.RawButton.LHandTrigger, Controller.ControlIndex)
			|| OVRInput.Get(OVRInput.RawButton.RHandTrigger, Controller.ControlIndex);
    }
    protected override bool RemoveObject()
	{
		return OVRInput.GetDown(OVRInput.RawButton.LHandTrigger, Controller.ControlIndex)
			|| OVRInput.GetDown(OVRInput.RawButton.RHandTrigger, Controller.ControlIndex);
    }
}
