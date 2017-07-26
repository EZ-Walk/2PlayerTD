using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dualcamera : MonoBehaviour {
    public Camera myTopDown;
    public bool isTopDownShowing;


	// Use this for initialization
	void Start () {
        updatecam();	
	}
	
	// Update is called once per frame
	void updatecam () {
        myTopDown.enabled = isTopDownShowing;
        UnityEngine.VR.VRSettings.showDeviceView = !isTopDownShowing;
	}

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.V) )
        {
            isTopDownShowing = !isTopDownShowing;
            updatecam();
        }
    }
}
