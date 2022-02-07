using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float speed;
    public float timer;
    public int max_int;
    public int min_int;

    private Vector2 newPosition;

    private Rigidbody2D rb2d;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        rb2d.velocity = newPosition.normalized * speed;

        if (timer < 0.0f)
        {
            if((-8 <= transform.position.x && transform.position.x <= 8) && (0 <= transform.position.y && transform.position.y <= 4))
            {
                newPosition = new Vector2(Random.Range(min_int, max_int), Random.Range(min_int, max_int));
            }
            else
            {
                newPosition = -newPosition;
            }
            

            timer = 1;
        }
        

    }
}
