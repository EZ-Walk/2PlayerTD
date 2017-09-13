using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broodMother : MonoBehaviour
{

	public GameObject childPrefab;

	public float speed = 10f;
	//public float health;
	public int HP;

	private string shooter;

	private Transform target;
	private int wavepointIndex = 0;

	private Vector3 broodPosition;
	private Vector3 child1Position;
	private Vector3 child2Position;
	private Vector3 child3Position;
	private Vector3 child4Position;


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

	public void checkHealth()
	{
		if (HP <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void takeHit(int param)
	{
		Debug.Log("Bullet ID = " + param);
		switch (param)
		{
			case 0:
				HP -= 100;
				shooter = "arrow";
				break;
			case 1:
				HP -= 50;
				shooter = "turret";
				break;

			case 2:
				//this case is for a pistol bullet
				HP -= 30;
				shooter = "pistol";
				break;

			case 3:
				//this is the case for the rifle bullet
				HP -= 200;
				shooter = "rifle";
				break;
		}

		if (HP <= 0)
		{
			spawnChildren();
			GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().increaseEnemiesKilled();

			AudioSource destroyEnemy = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().enemyDestroyed;
			destroyEnemy.Play();
			Destroy(this.gameObject);
		}
	}

	private void spawnChildren()
	{
		broodPosition = this.transform.position;

		//Spawn children
		Instantiate(childPrefab, child1Position, this.transform.rotation);
		Instantiate(childPrefab, child2Position, this.transform.rotation);
		Instantiate(childPrefab, child3Position, this.transform.rotation);
		Instantiate(childPrefab, child4Position, this.transform.rotation);
	}
}
