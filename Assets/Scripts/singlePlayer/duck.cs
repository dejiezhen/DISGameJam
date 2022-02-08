using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class duck : MonoBehaviour
{
  
    private Rigidbody2D myRb2D;
    public Canvas win;
    public float jumpForce;
    private bool grounding;

    private float jumpCount;
    private float timer;
    private SpriteRenderer sr;
    public Sprite idle;
    public Sprite jump;

    public GameObject balloon1;
    public GameObject balloon2;
    public float hitForce;
    Vector2 vel;

    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        sr= GetComponent<SpriteRenderer>();

        vel = myRb2D.velocity;


        jumpCount = 0;
        win.enabled = false;
        balloon1.gameObject.SetActive(false);
        balloon2.gameObject.SetActive(false);
        timer = 0;
        sr.sprite = idle;

    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 normalizedDir = myRb2D.velocity.normalized;
        //transform.position += Vector3.right * speed * Time.deltaTime;
        if (jumpCount == 20)
        {
            win.enabled = true;
            balloon1.gameObject.SetActive(true);
            balloon2.gameObject.SetActive(true);
            timer++;
            if (timer >= 150)
            {
                SceneManager.LoadScene("mainMenu");
            }
            
        }
        vel = myRb2D.velocity;
        if (Input.GetKeyDown(KeyCode.Space) && grounding) //sprite up
        {

            vel.y = jumpForce;
            myRb2D.velocity = vel;
            grounding = false;
            sr.sprite = jump;


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounding = true;
            sr.sprite = idle;

            jumpCount++;
            
        }


        if (collision.gameObject.CompareTag("Lava"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.CompareTag("Ball"))
        {
            vel.x = hitForce;
            myRb2D.velocity = vel;

        }
    }
}
