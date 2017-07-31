using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionCube : MonoBehaviour {

    public GameObject targetResourceNode;
    private bool isMinerPresent = false;


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("on trigger enter");
        targetResourceNode = other.gameObject;
        Debug.Log("target node is set");
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("on trigger exit");
        targetResourceNode = null;
    }
}
