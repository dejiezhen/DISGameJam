using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_1_Scoreboard : MonoBehaviour
{
    public Sprite[] Scores;

    public int score_counter;

    public float contstant_timer;

    private float timer;

    private SpriteRenderer current_score;

    private void Start()
    {
        current_score = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        current_score.sprite = Scores[score_counter];

        if(score_counter >= 3)
        {

        }

    }

    public void increment()
    {
        if(score_counter < 4 && timer <= 0)
        {
            Debug.Log("coin");
            score_counter++;
            timer = contstant_timer;
        }
        
    }

    public void decrease()
    {
        if (score_counter > 0)
        {
            Debug.Log("work");
            score_counter--;
        }
    }

}
