using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTrigger : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision started");
    }
}
