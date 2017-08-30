using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolBullet : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Enemy") == true)
        {
            collision.gameObject.GetComponent<EnemyScript>().takeHit(2);
            Debug.Log(collision.gameObject.name + " ");
        }
    }
}
