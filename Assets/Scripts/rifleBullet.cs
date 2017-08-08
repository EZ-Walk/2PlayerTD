using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifleBullet : MonoBehaviour {

    public GameObject impactEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Enemy") == true)
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);

            collision.gameObject.GetComponent<EnemyScript>().takeHit(3);
            AudioSource audio = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<AudioSource>();
            audio.Play();

            Destroy(gameObject); //Destroy bullet
        }

    }
}
