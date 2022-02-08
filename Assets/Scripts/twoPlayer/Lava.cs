using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform.position;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //other.transform.position = respawnPoint.position;
        if (other.tag == "Player")
        {
            other.transform.position = respawnPoint;
        }

    }

}