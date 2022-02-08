using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    // Start is called before the first frame update
    public float knockbackForce;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            Player enemy = collision.gameObject.GetComponent<Player>();
            Knockback(enemy);
        }
    }

    public void Knockback(Player enemy)
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
