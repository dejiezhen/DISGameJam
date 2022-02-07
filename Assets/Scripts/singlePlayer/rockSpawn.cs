using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockSpawn : MonoBehaviour
{
    public GameObject Obstacle;
    private float timer;
    public float spawnTimer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnNewObstacle();
            timer = spawnTimer;
        }
    }

    private void SpawnNewObstacle()
    {
        Vector3 SpawnPositionDown = transform.position + Vector3.down * Random.Range(-12, -7);
        Vector3 SpawnPositionUp = transform.position + Vector3.up * Random.Range(-10, -1);
        SpawnPositionDown.z = 0;
        SpawnPositionUp.z = 0;
        Instantiate(Obstacle, SpawnPositionDown, Quaternion.identity);
       
    }
}
