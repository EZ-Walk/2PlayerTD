using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longneck : MonoBehaviour {
    public static GameObject target;
    public static int health;

    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;


    // Use this for initialization
    void Start () {
        InvokeRepeating("updateTarget", 0f, 0.5f);
    }

    void updateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(bulletPrefab.transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
