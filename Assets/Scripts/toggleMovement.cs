using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class toggleMovement : MonoBehaviour {

    public bool isWalkingPrefered = true;
    public Component pointerScript;

	public void toggleMovementMode ()
    {
        isWalkingPrefered = !isWalkingPrefered;
        if (isWalkingPrefered)
        {
            pointerScript.gameObject.SetActive(false);
            gameObject.GetComponent<VRTK_Pointer>().enabled = false;
        }
    }
}
