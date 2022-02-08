using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_Scoreboard : MonoBehaviour
{
    public Sprite[] Scores;

    public int score_counter;

    private SpriteRenderer current_score;

    private void Start()
    {
        current_score = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        current_score.sprite = Scores[score_counter];
    }

    public void increment()
    {
        if(score_counter < 3)
        {
           Debug.Log("coin");
           score_counter++;
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
