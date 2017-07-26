using UnityEngine;

public class shop : MonoBehaviour {

    BuildManager buildManager;

    public static int costOfCurrentTurret;
    public static int metalCostOfCurrentTurret;
    public static int electricGelCostOfCurrentTurret;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void purchaseStandardTurret()
    {
        Debug.Log("standard turret purchased");
        costOfCurrentTurret = 100;
        metalCostOfCurrentTurret = 50;
        electricGelCostOfCurrentTurret = 75;
        buildManager.setTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void purchaseTurretV3()
    {
        Debug.Log("turretV3 purchased");
        costOfCurrentTurret = 300;
        metalCostOfCurrentTurret = 100;
        electricGelCostOfCurrentTurret = 250;
        buildManager.setTurretToBuild(buildManager.andAnotherTurretPrefab);
    }

    public void purchaseBowV2()
    {
        Debug.Log("bowV2 purchased");
        GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().buyBowV2();
    }

    public void purchaseBowV3()
    {
        Debug.Log("bowV3 purchased");
        GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().buyBowV3();
    }
}
