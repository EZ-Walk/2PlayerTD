using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMiner : MonoBehaviour {
    public static int targetResource;

    public int harvestMult = 1;

    public int electricGelHarvestRate = 3;
    public int metalHarvestRate = 1;

    public Color defaultColor;
    public Color harvestColor;

	// Use this for initialization
	void Start () {
        InvokeRepeating("harvestResource", 0, 2);
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

    void changeColor()
    {
        if (this.GetComponent<Renderer>().sharedMaterial.color == harvestColor)
        {
            this.GetComponent<Renderer>().sharedMaterial.color = defaultColor;
        }
        else
        {
            this.GetComponent<Renderer>().sharedMaterial.color = harvestColor;
        }
    }
}
