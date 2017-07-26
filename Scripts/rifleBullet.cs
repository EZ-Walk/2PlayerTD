using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifleBullet : MonoBehaviour {

    public int speed;

    private void Update()
    {
        if (longneck.target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = longneck.target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            Debug.Log("Thats a hit!");
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
}
