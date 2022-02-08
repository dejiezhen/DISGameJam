using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private Vector3 respawnPoint;
    public AudioClip[] lavaSound;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //other.transform.position = respawnPoint.position;
        if (other.tag == "Player")
        {
            audio.PlayOneShot(lavaSound[0]);
            other.transform.position = respawnPoint;
        }

    }

}