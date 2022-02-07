using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1G2 : Player
{

    public float jumpForce, sideForce;
    public int currentFrame;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public Sprite[] spriteSideFrames;
    public Sprite[] spriteAttack;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        currentFrame = 1;
    }

    // Update is called once per frame
    void Update()
    {
        sr.sprite = spriteSideFrames[0];

        bool groundCheck= Physics2D.Raycast(transform.position, Vector2.down, .35f, LayerMask.GetMask("Floor"));
        if (Input.GetKeyDown(KeyCode.W) && groundCheck)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        if (Input.GetKey(KeyCode.A))
        {
  
            sr.flipX = true;
            spriteAnimation(spriteSideFrames, spriteSideFrames.Length);
            rb.AddForce(Vector2.left * sideForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            sr.flipX = false;
            spriteAnimation(spriteSideFrames, spriteSideFrames.Length);
            rb.AddForce(Vector2.right * sideForce);
        }

        Vector2 origin = transform.position;
        Vector2 horizontalTarget = origin;
        Vector2 verticalTarget = origin;
        Vector2 horizontalDir = horizontalTarget - origin;
        Vector2 verticalDir = verticalTarget - origin;

        RaycastHit2D hitLeft = Physics2D.Raycast(origin, -horizontalDir, horizontalDir.magnitude);
        RaycastHit2D hitRight = Physics2D.Raycast(origin, horizontalDir, horizontalDir.magnitude);
        horizontalTarget.x += 1;
        verticalTarget.y += 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sr.sprite = spriteAttack[0];
            if (hitLeft)
            {
                HitDirection(hitLeft);
            } else if (hitRight)
            {
                HitDirection(hitRight);
            }
        }

      }
    public void HitDirection(RaycastHit2D hit)
    {
        Player player = hit.collider.gameObject.GetComponent<Player>();
        if (player)
        {
            player.Knockback();
        }
    }
    public void spriteAnimation(Sprite[] frames, int frameLength)
    {
        if (currentFrame >= frameLength)
        {
            currentFrame = 1;
        }
        sr.sprite = frames[currentFrame];
        currentFrame++;
    }

    public override void Knockback()
    {
        if(sr.flipX)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);

        } else
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);

        }
    }
}
