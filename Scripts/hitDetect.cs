using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitDetect : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Enemy") == true)
        {
            collision.gameObject.GetComponent<EnemyScript>().takeHit(0);
            Debug.Log(collision.gameObject.name + " ");
            GameMaster.gold += 50;
        }
        
    }
}
