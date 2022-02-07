using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float movementHorizontal, movementVertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = 0;
        movementVertical = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movementVertical = speed;
            //spriteAnimation(spriteUpFrames, spriteUpFrames.Length);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movementVertical = -speed;
            //spriteAnimation(spriteDownFrames, spriteDownFrames.Length);


        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementHorizontal = -speed;
            //spriteAnimation(spriteSideFrames, spriteSideFrames.Length);
            //sr.flipX = true;


        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movementHorizontal = speed;
            //sr.flipX = false;
            //spriteAnimation(spriteSideFrames, spriteSideFrames.Length);


        }
    }
}
