using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2G2 : Player
{
    // Start is called before the first frame update
    public float jumpForce, sideForce, knockbackForce,moveX, moveY;
    public int currentFrame;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public Sprite[] spriteSideFrames;
    public Sprite[] spriteAttack;
    public Player_1_Scoreboard P2Score;
    public AudioClip[] attackSound;
    private AudioSource myAudioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        myAudioSource = GetComponent<AudioSource>();

        currentFrame = 1;
    }

    
    void Update()
    {
        sr.sprite = spriteSideFrames[0];
        sr.color = new Color(0, 255, 255, 255);

        moveX = 0;
        moveY = 0;

        bool groundCheck = Physics2D.Raycast(transform.position, Vector2.down, .5f, LayerMask.GetMask("Floor"));
        bool secondGroundCheck = Physics2D.Raycast(transform.position, Vector2.down, .5f, LayerMask.GetMask("obstacle"));

        if (Input.GetKeyDown(KeyCode.UpArrow) && (groundCheck || secondGroundCheck))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {


            sr.flipX = true;
            spriteAnimation(spriteSideFrames, spriteSideFrames.Length);
            //rb.AddForce(Vector2.left * sideForce);
            moveX = -sideForce;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            spriteAnimation(spriteSideFrames, spriteSideFrames.Length);
            moveX = sideForce;
        }

        rb.velocity = new Vector2(moveX, rb.velocity.y);


        Vector2 origin = transform.position;
        Vector2 horizontalTarget = origin;

        //horizontalTarget.x += 3;
        //Vector2 horizontalDir = horizontalTarget - origin;

        //RaycastHit2D hitLeft = Physics2D.Raycast(origin, -horizontalDir, horizontalDir.magnitude);
        //RaycastHit2D hitRight = Physics2D.Raycast(origin, horizontalDir, horizontalDir.magnitude);

        if (Input.GetKey(KeyCode.RightShift))
        {
            sr.sprite = spriteAttack[0];
            myAudioSource.PlayOneShot(attackSound[0]);

        }

    }

    public void spriteAnimation(Sprite[] frames, int frameLength)
    {
        if (currentFrame >= frameLength)
        {
            currentFrame = 1;
        }
        sr.sprite = frames[currentFrame];
        sr.color = new Color(0, 255, 255, 255);
        currentFrame++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.RightShift))
        {
            Debug.Log("Hit");
            Player enemy = collision.gameObject.GetComponent<Player>();
            Knockback(enemy);
        }

        if (collision.gameObject.CompareTag("coin"))
        {
            Debug.Log("Hit COIN");
            P2Score.increment();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            Debug.Log("hit lava");
            P2Score.decrease();
        }
    }

    public override void Knockback(Player enemy)
    {
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
