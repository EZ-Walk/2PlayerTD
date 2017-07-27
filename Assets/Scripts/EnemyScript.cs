using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour {

    public float speed = 10f;
    public static float health;
    public int HP;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
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
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log(HP);
        }
    }

    public void takeHit(int param)
    {
        switch(param)
        {
            case 0:
                HP -= 100;
                Debug.Log("The ranger has hit an enemy with an arrow");
                checkHealth();
                break;
            case 1:
                HP -= 50;
                Debug.Log("A turret has hit an enemy");
                checkHealth();
                break;

            case 2:
                //this case is for a pistol bullet
                HP -= 30;
                Debug.Log("Ranger has hit an enemy with a pistol");
                checkHealth();
                break;

            case 3:
                //this is the case for the rifle bullet
                HP -= 200;
                Debug.Log("Ranger has hit an enemy with a rifle");
                checkHealth();
                break;
        }

        if (HP == 0)
        {
            if (gameObject.name.Contains("Snowman"))
            {
                Debug.Log("you hit a snowman");
                Destroy(gameObject);
                GameMaster.gold += 50;
            }
            else if (gameObject.name.Contains("BalloonEnemy"))
            {
                Debug.Log("You hit a balloon");
                Destroy(gameObject);
                GameMaster.gold += 20;
            }
            else if (gameObject.name.Contains("redBall"))
            {
                Debug.Log("You hit a red ball");
                Destroy(gameObject);
                GameMaster.gold += 30;
            }
            else if (gameObject.name.Contains("Barbarian"))
            {
                Debug.Log("You hit a barbarian");
                Destroy(gameObject);
                GameMaster.gold += 125;
            }

            GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().increaseEnemiesKilled();

            AudioSource destroyEnemy = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().enemyDestroyed;
            destroyEnemy.Play();
            Destroy(this.gameObject);
        }
    }

    void checkIfDead()
    {
        if (HP == 0)
        {
            if (gameObject.name.Contains("Snowman"))
            {
                Debug.Log("you hit a snowman");
                Destroy(gameObject);
                GameMaster.gold += 50;
            }
            else if (gameObject.name.Contains("BalloonEnemy"))
            {
                Debug.Log("You hit a balloon");
                Destroy(gameObject);
                GameMaster.gold += 20;
            }
            else if (gameObject.name.Contains("redBall"))
            {
                Debug.Log("You hit a red ball");
                Destroy(gameObject);
                GameMaster.gold += 30;
            }
            else if (gameObject.name.Contains("Barbarian"))
            {
                Debug.Log("You hit a barbarian");
                Destroy(gameObject);
                GameMaster.gold += 125;
            }

            GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().increaseEnemiesKilled();

            AudioSource destroyEnemy = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().enemyDestroyed;
            destroyEnemy.Play();
            Destroy(this.gameObject);
        }
    }
}
