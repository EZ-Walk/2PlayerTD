using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleBullet : MonoBehaviour {

    public GameObject impactEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Enemy") == true)
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);

            collision.gameObject.GetComponent<EnemyScript>().takeHit(2);
            Debug.Log("should trigger takeHit(2)");
            AudioSource audio = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<AudioSource>();
            audio.Play();

            Destroy(gameObject); //Destroy bullet
        }

    }
}
