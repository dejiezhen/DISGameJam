using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_1_Scoreboard : MonoBehaviour
{
    public Sprite[] Scores;

    public int score_counter;

    public float contstant_timer;

    public float loadMainScreenTimer;

    private float timer;

    private SpriteRenderer current_score;

    private void Start()
    {
        current_score = GetComponent<SpriteRenderer>();
        loadMainScreenTimer = 5;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        current_score.sprite = Scores[score_counter];

        if(score_counter >= 4)
        {
            loadMainScreenTimer -= Time.deltaTime;
            if (loadMainScreenTimer <= 0)
            {
                SceneManager.LoadScene("mainMenu");

            }
 
        }

    }

    public void pauseGame()
    {
        StartCoroutine(GamePauser());
    }
    public IEnumerator GamePauser()
    {
        Debug.Log("Inside PauseGame()");
        yield return new WaitForSeconds(3);
        Debug.Log("Done with my pause");
        SceneManager.LoadScene("mainMenu");

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
