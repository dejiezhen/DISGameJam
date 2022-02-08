using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2G2 : Player
{
    // Start is called before the first frame update
    public float jumpForce, sideForce, knockbackForce;
    public int currentFrame;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public Sprite[] spriteSideFrames;
    public Sprite[] spriteAttack;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        currentFrame = 1;
    }

    
    void Update()
    {
        sr.sprite = spriteSideFrames[0];
        sr.color = new Color(0, 255, 255, 255);

        bool groundCheck = Physics2D.Raycast(transform.position, Vector2.down, .5f, LayerMask.GetMask("Floor"));
        if (Input.GetKeyDown(KeyCode.UpArrow) && groundCheck)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            sr.flipX = true;
            spriteAnimation(spriteSideFrames, spriteSideFrames.Length);
            rb.AddForce(Vector2.left * sideForce);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            spriteAnimation(spriteSideFrames, spriteSideFrames.Length);
            rb.AddForce(Vector2.right * sideForce);
        }

        Vector2 origin = transform.position;
        Vector2 horizontalTarget = origin;

        //horizontalTarget.x += 3;
        //Vector2 horizontalDir = horizontalTarget - origin;

        //RaycastHit2D hitLeft = Physics2D.Raycast(origin, -horizontalDir, horizontalDir.magnitude);
        //RaycastHit2D hitRight = Physics2D.Raycast(origin, horizontalDir, horizontalDir.magnitude);

        if (Input.GetKey(KeyCode.RightShift))
        {
            sr.sprite = spriteAttack[0];
            //if (hitLeft)
            //{
            //    HitDirection(hitLeft);
            //}
            //if (hitRight)
            //{
            //    HitDirection(hitRight);
            //}
        }

    }
    //public void HitDirection(RaycastHit2D hit)
    //{
    //    var player = hit.collider.gameObject.GetComponent<Player1G2>();
    //    if (player)
    //    {
    //        Debug.Log("Hit!");
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
