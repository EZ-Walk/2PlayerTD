using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelect : MonoBehaviour {

    public void NextLevelButton(string name)
    {
        Application.LoadLevelAsync(name);
        Debug.Log("ran it");
    }
}
