﻿using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class VRSettingsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //If V is pressed, toggle VRSettings.enabled
        if (Input.GetKeyDown(KeyCode.V))
        {
            VRSettings.enabled = !VRSettings.enabled;
            Debug.Log("Changed VRSettings.enabled to:" + VRSettings.enabled);
        }

        for (int i = 0; i < 16; i++)
        {
            if (SteamVR_Controller.Input(i).GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("main");
            }
        }
    }
}
