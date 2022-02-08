using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public float speed;

    //max and min values for x and y components of the new position point
    public int max_int;
    public int min_int;

    //position that the coin will atempt to fly to
    private Vector2 newPosition;

    private Rigidbody2D rb2d;

    [SerializeField] private LayerMask layerMask;

    //time before the coin gets a new waypoint
    private float timer = 0.7f;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //timer counts down every frame
        timer -= Time.deltaTime;

        //coin travels towards the direction of new position with given speed
        rb2d.velocity = newPosition.normalized * speed;

   
        if (timer < 0.0f)
        {
            //once the timer runs out if the coin is within the range -9 <= x <= 9 and -2 <= x <= 5 give it a new random waypoint
            if ((-9 <= transform.position.x && transform.position.x <= 9) && (-2 <= transform.position.y && transform.position.y <= 6))
            {
                newPosition = new Vector2(Random.Range(min_int, max_int), Random.Range(min_int, max_int));
            }
            else
            {
                // if coin is out if bounds return into bounds
                newPosition = -(newPosition + newPosition.normalized);
            }

            //reset the timer
            timer = 0.7f;
        }
        

    }
}
