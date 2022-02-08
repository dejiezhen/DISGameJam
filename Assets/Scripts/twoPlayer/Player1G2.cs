using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1G2 : Player
{

    public float jumpForce, sideForce, knockbackForce;
    public int currentFrame;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public Sprite[] spriteSideFrames;
    public Sprite[] spriteAttack;

    public Player_1_Scoreboard P1Score;

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

        bool groundCheck= Physics2D.Raycast(transform.position, Vector2.down, .5f, LayerMask.GetMask("Floor"));
        bool secondGroundCheck = Physics2D.Raycast(transform.position, Vector2.down, .5f, LayerMask.GetMask("obstacle"));
        if (Input.GetKeyDown(KeyCode.W) && (groundCheck || secondGroundCheck))
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

        //Vector2 origin = transform.position;
        //Vector2 horizontalTarget = origin;
        ////Vector2 verticalTarget = origin;
        //horizontalTarget.x += 1;
        ////verticalTarget.y += 1;
        //Vector2 horizontalDir = horizontalTarget - origin;
        ////Vector2 verticalDir = verticalTarget - origin;

        //RaycastHit2D hitLeft = Physics2D.Raycast(origin, -horizontalDir, horizontalDir.magnitude);
        //RaycastHit2D hitRight = Physics2D.Raycast(origin, horizontalDir, horizontalDir.magnitude);
     
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sr.sprite = spriteAttack[0];

            //if (hitLeft)
            //{
            //    HitDirection(hitLeft);
            //} else if (hitRight)
            //{
            //    HitDirection(hitRight);
            //}
        }

      }
    //public void HitDirection(RaycastHit2D hit)
    //{
    //    Player player = hit.collider.gameObject.GetComponent<Player>();
    //    if (player)
    //    {
    //        //player.Knockback();
    //    }
    //}
    public void spriteAnimation(Sprite[] frames, int frameLength)
    {
        if (currentFrame >= frameLength)
        {
            currentFrame = 1;
        }
        sr.sprite = frames[currentFrame];
        currentFrame++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            Player enemy = collision.gameObject.GetComponent<Player>();
            Knockback(enemy);
        }

        if (collision.gameObject.CompareTag("coin"))
        {
            Debug.Log("Hit COIN");
            P1Score.increment();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            Debug.Log("hit lava");
            P1Score.decrease();
        }
    }

    public override void Knockback(Player enemy)
    {
        Debug.Log("Knock!");
        Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
        SpriteRenderer enemySr = enemy.GetComponent<SpriteRenderer>();
        if (enemySr.flipX)
        {
            enemyRb.velocity = new Vector2(knockbackForce, knockbackForce);

        }
        else
        {
            enemyRb.velocity = new Vector2(-knockbackForce, knockbackForce);

        }
    }
}
