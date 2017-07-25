using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour {

    public float speed = 10f;
    public static float health;
    public float HP = 100f;

    private float distanceToBullet;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        if (gameObject.name.Contains("Snowman")) HP = 200;
        else if (gameObject.name.Equals("BalloonEnemy")) HP = 100;
        else if (gameObject.name.Contains("redBall")) HP = 150;
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

    public void checkHealth ()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeHit(int param)
    {
        switch(param)
        {
            case 0:
                HP -= 100;
                Debug.Log("The ranger has hit an enemy");
                break;
            case 1:
                HP -= 50;
                Debug.Log("A turret has hit an enemy");
                break;
        }
        if (HP == 0)
        {
            if (gameObject.name.Contains("Snowman"))
            {
                Debug.Log("you hit a snowman");
                GameMaster.gold += 50;
                GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().updateGold();
            }
            else if (gameObject.name.Contains("BalloonEnemy"))
            {
                Debug.Log("You hit a balloon");
                GameMaster.gold += 20;
                GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().updateGold();
            }
            GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().increaseEnemiesKilled();

            AudioSource destroyEnemy = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().enemyDestroyed;
            destroyEnemy.Play();
            Destroy(this.gameObject);
        }
    }
}
