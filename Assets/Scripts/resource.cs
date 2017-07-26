using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource : MonoBehaviour {
    public int targetResource;
    // 0 = electricGel, 1 = metal
    private bool isMinerPresent = false;
    public GameObject minerPrefab;
    public Color harvestColor;
    public Color defaultColor;
    public Transform minerAttatch;

    public void buildMiner()
    {
        Instantiate(minerPrefab, minerAttatch);
        isMinerPresent = true;
        InvokeRepeating("harvestResource", 0, 3);
    }

    public void destroyMiner()
    {
        // how do i destroy the miner?
        isMinerPresent = false;
        CancelInvoke();
    }

    void harvestResource()
    {
        if (targetResource == 0)
        {
            GameMaster.electricGel += 10;
            changeColor();
        }
        else if (targetResource == 1)
        {
            GameMaster.metal += 5;
            changeColor();
        }
    }

    void changeColor ()
    {
        if (minerPrefab.GetComponent<Renderer>().sharedMaterial.color == harvestColor)
        {
            minerPrefab.GetComponent<Renderer>().sharedMaterial.color = defaultColor;
        } else
        {
            minerPrefab.GetComponent<Renderer>().sharedMaterial.color = harvestColor;
        }
    }
}
