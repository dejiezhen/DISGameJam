using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solid_Platform : MonoBehaviour
{

    public float contantTime;

    private float DistructionTimer;

    private float RespawnTimer;


    void Update()
    {
        if (DistructionTimer <= 0.0f)
        {
            Destroy(gameObject);
            DistructionTimer = contantTime;
            RespawnTimer -= Time.deltaTime;
        }
        if(RespawnTimer <= 0.0f)
        {
            Instantiate(gameObject, transform.position, Quaternion.identity);
            RespawnTimer = contantTime;
        }

    }

    private void OnCollisionEnter(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            DistructionTimer -= Time.deltaTime;
        }
    }

}
