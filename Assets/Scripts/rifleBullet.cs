using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifleBullet : MonoBehaviour {

    VRTK.Examples.RealGun realGun;

    private void Start()
    {
        realGun = VRTK.Examples.RealGun.instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Enemy") == true)
        {
            collision.gameObject.GetComponent<EnemyScript>().takeHit(3);
            Debug.Log(collision.gameObject.name + " ");
        }
    }
}
