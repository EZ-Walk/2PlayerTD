using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("there are more than one build managers");
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;
    public GameObject andAnotherTurretPrefab;

    private GameObject turretToBuild;

    public GameObject getTurretToBuild ()
    {
        return turretToBuild;
    }

    public void setTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }
}