using UnityEngine;
using System.Collections;
using System;

public class TouchControllerBase : MonoBehaviour
{
    [SerializeField]
    private GameObject PointerRayPrefab;
    [SerializeField]
    private bool HideTrackhat;
    [SerializeField]
    public OVRInput.Controller ControlIndex;

    [NonSerialized]
    public Transform Trans;
    [NonSerialized]
    public Transform PointerTrans;
    [NonSerialized]
    public bool ShowPointer;

    private bool TrackhatHidden;

    void Awake()
    {
        Trans = transform;

        var instance = Instantiate(PointerRayPrefab);
        PointerTrans = instance.transform;
        PointerTrans.SetParent(Trans, false);
        PointerTrans.gameObject.SetActive(false);
    }

    void Update()
    {
        PointerTrans.gameObject.SetActive(ShowPointer);
        ShowPointer = false;

        DoHideTrackhat();
    }

    private void DoHideTrackhat()
    {
        if (TrackhatHidden == false && HideTrackhat)
        {
            var renderComp = GetComponentInChildren<SteamVR_RenderModel>();
            renderComp.updateDynamically = false;

            foreach (var comp in GetComponentsInChildren<Transform>())
            {
                if (comp.gameObject.name.ToLower() == "trackhat")
                {
                    TrackhatHidden = true;
                    comp.gameObject.SetActive(false);
                }
            }
        }
    }

    public void ShowControllerPointer()
    {
        ShowPointer = true;
    }

    public void HapticPulse(int durationMS, byte strength)
    {
        int size = (int)(320f * (durationMS / 1000f));
        byte[] bytes = new byte[size];
        for (int i = 0; i < bytes.Length; i++)
            bytes[i] = strength;

        OVRHapticsClip hapticData = new OVRHapticsClip(bytes, size);
        OVRHaptics.LeftChannel.Preempt(hapticData);
    }
}
