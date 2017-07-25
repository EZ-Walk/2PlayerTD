using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleBullet : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") == true)
        {

            Debug.Log("health is now " + EnemyScript.health);
            if (EnemyScript.health <= 0)
            {

                Destroy(gameObject);
                Debug.Log("destroyed the game object in the update function");

            } else
            {
                EnemyScript.health -= 50;
            }
            Debug.Log("Simple bullet has hit for 50 dmg");
        }
    }
}
