using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource : MonoBehaviour {
    public int targetResource;
    // 0 = electricGel, 1 = metal
    private bool isMinerPresent = false;
    public GameObject minerPrefab;
    public GameObject advancedMinerPrefab;
    public GameObject industrialMinerPrefab;
    public Color harvestColor;
    public Color defaultColor;
    public Transform minerAttatch;
    private int harvestMult;

    private GameObject Miner;

    public int electricGelHarvestRate = 3;
    public int metalHarvestRate = 1;

    public void buildMiner()
    {
        if (isMinerPresent)
        {
            destroyMiner();
        } else if (GameMaster.gold >= 100)
        {
            Miner = Instantiate(minerPrefab, minerAttatch);
            GameMaster.gold -= 100;
            isMinerPresent = true;
            harvestMult = 1;
            InvokeRepeating("harvestResource", 0, 3);
        }
    }

    public void buildAdvancedMiner()
    {
        if (isMinerPresent)
        {
            destroyMiner();
        }
        else if (GameMaster.gold >= 300)
        {
            Miner = Instantiate(advancedMinerPrefab, minerAttatch);
            GameMaster.gold -= 300;
            isMinerPresent = true;
            harvestMult = 2;
            InvokeRepeating("harvestResource", 0, 3);
        }
    }

    public void buildIndustrialMiner()
    {
        if (isMinerPresent)
        {
            destroyMiner();
        }
        else if (GameMaster.gold >= 1000)
        {
            Miner = Instantiate(industrialMinerPrefab, minerAttatch);
            GameMaster.gold -= 1000;
            isMinerPresent = true;
            harvestMult = 4;
            InvokeRepeating("harvestResource", 0, 3);
        }
    }

    public void destroyMiner()
    {
        // how do i destroy the miner?
        isMinerPresent = false;
        Destroy(Miner.gameObject);
        Debug.Log("miner destroyed");
        CancelInvoke();
    }

    void harvestResource()
    {
        if (targetResource == 0)
        {
            GameMaster.electricGel += electricGelHarvestRate * harvestMult;
            changeColor();
        }
        else if (targetResource == 1)
        {
            GameMaster.metal += metalHarvestRate * harvestMult;
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
