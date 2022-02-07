using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float speed;

    public float timer;

    private Vector2 newPosition;

    private Rigidbody2D rb2d;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        rb2d.velocity = newPosition * speed;

        if (timer < 0.0f)
        {
            if (transform.position.x > -8 && transform.position.x < 8 && transform.position.y < 4 && transform.position.y > 0);
            {
                newPosition = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
            }


            timer = 1;
        }
        

    }
}
