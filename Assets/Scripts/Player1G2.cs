using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1G2 : MonoBehaviour
{
    public float movementHorizontal, movementVertical, speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = 0;
        movementVertical = 0;
        if (Input.GetKey(KeyCode.W))
        {
            movementVertical = speed * 1;
            //spriteAnimation(spriteUpFrames, spriteUpFrames.Length);

        }
        if (Input.GetKey(KeyCode.A))
        {
            movementHorizontal = -speed;
            //spriteAnimation(spriteSideFrames, spriteSideFrames.Length);
            //sr.flipX = true;


        }
        if (Input.GetKey(KeyCode.D))
        {
            movementHorizontal = speed;
            //sr.flipX = false;
            //spriteAnimation(spriteSideFrames, spriteSideFrames.Length);


        }
        rb.velocity = new Vector2(movementHorizontal, movementVertical) * speed;


    }
}
