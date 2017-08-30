using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    private Color startColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;

    BuildManager buildManager;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.getTurretToBuild() == null)
        {
            return;
        }

        if ( turret != null)
        {
            Destroy(turret.gameObject);
            AudioSource turretDestroyed = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().turretDestroyed;
            turretDestroyed.Play();
            GameMaster.gold += 100;
            GameMaster.metal += 25;
            GameMaster.electricGel += 50;
            return;
        }

        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();

        if (GameMaster.gold >= shop.costOfCurrentTurret && GameMaster.metal >= shop.metalCostOfCurrentTurret && GameMaster.electricGel >= shop.electricGelCostOfCurrentTurret)
        {
            turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            AudioSource turretPlaced = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().turretPlaced;
            turretPlaced.Play();
            GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().builtTurret();
            GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().clearInfo();
        }
        else
        {
            GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().notEnoughGold();
        }
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.getTurretToBuild() == null)
        {
            return;
        }

        GetComponent<Renderer>().material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
