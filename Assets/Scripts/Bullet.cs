using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour {

    private Transform target;

    public GameObject enemiesKilled;

    public float speed = 70f;

    public GameObject impactEffect;


    public void Seek (Transform target)
    {
        this.target = target;
    }
	
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            Debug.Log("Thats a hit!");
            HitTarget();
            return;
        }

        transform.Translate (dir.normalized * distanceThisFrame, Space.World);

	}

    void HitTarget ()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        target.GetComponent<EnemyScript>().takeHit(1);
        AudioSource audio = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<AudioSource>();
        audio.Play();

        Destroy(gameObject); //Destroy bullet
    }        
}
