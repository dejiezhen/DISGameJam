using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{

    float BombExplosionTimer;

    public Sprite[] frames;
    public float animationFPS;
    SpriteRenderer sr;
    int currentFrame;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        BombExplosionTimer = 0;
        currentFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        BombExplosionTimer -= Time.deltaTime;
        if (BombExplosionTimer <= 0)
        {
            sr.sprite = frames[currentFrame];
            BombExplosionTimer = 1 / animationFPS;
            currentFrame++;

            if (currentFrame >= frames.Length)
            {
                currentFrame = 0;
            }
        }
    }
}
