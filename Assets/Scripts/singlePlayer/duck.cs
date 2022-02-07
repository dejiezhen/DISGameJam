using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class duck : MonoBehaviour
{
  
    private Rigidbody2D myRb2D;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 normalizedDir = myRb2D.velocity.normalized;
        //transform.position += Vector3.right * speed * Time.deltaTime;

        Vector2 vel = myRb2D.velocity;
        if (Input.GetKeyDown(KeyCode.Space)) //sprite up
        {

            vel.y = jumpForce;
            myRb2D.velocity = vel;

        }

    }
}
