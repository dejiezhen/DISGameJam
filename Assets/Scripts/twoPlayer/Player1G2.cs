using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1G2 : Player
{

    public float jumpForce, sideForce, knockbackForce, moveX, moveY;
    public int currentFrame;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public Sprite[] spriteSideFrames;
    public Sprite[] spriteAttack;
    public Player_1_Scoreboard P1Score;
    public AudioClip[] attackSound;
    private AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //attackSound = GetComponent<AudioSource>();
        currentFrame = 1;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.sprite = spriteSideFrames[0];

        moveX = 0;
        moveY = 0;

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
            //rb.AddForce(Vector2.left * sideForce);
            moveX = -sideForce;
        }
        if (Input.GetKey(KeyCode.D))
        {
            sr.flipX = false;
            spriteAnimation(spriteSideFrames, spriteSideFrames.Length);
            moveX = sideForce;
        }

        rb.velocity = new Vector2(moveX, rb.velocity.y);
     
        if (Input.GetKey(KeyCode.LeftShift))
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
