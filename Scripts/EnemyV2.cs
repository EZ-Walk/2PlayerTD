using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV2 : MonoBehaviour
{

    public float speed = 10f;
    public static float health;
    public float HP = 100f;


    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        health = HP;
        target = WaypointsScript.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.LookAt(target);
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= .5)
        {
            getNextWaypoint();
        }
    }

    void getNextWaypoint()
    {
        if (wavepointIndex >= WaypointsScript.points.Length - 1)
        {
            GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().enemyReachesEnd();
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = WaypointsScript.points[wavepointIndex];
    }
}
