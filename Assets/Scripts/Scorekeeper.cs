using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] int points = 0;
    [SerializeField] int SCORE_THRESHOLD = 3;
    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;
    [SerializeField] Text playerNameText;
    [SerializeField] int level;
    [SerializeField] GameObject balloon;
    const float delayTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        score = PersistantData.Instance.GetScore();
        level = SceneManager.GetActiveScene().buildIndex;
        DisplayLevel();
        DisplayScore();
        DisplayName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints() 
    {
        balloon = GameObject.FindGameObjectWithTag("Balloon");
        if(balloon.transform.localScale.x<=1.0f && balloon.transform.localScale.y<=1.0f) {
            points = 3;
            score += points;
        }
        else if(balloon.transform.localScale.x<=2.0f && balloon.transform.localScale.y<=2.0f) {
            points = 2;
            score += points;
        }
        else if(balloon.transform.localScale.x<=3.0f && balloon.transform.localScale.y<=3.0f) {
            points = 1;
            score += points;
        }
        PersistantData.Instance.SetScore(score);
        DisplayScore();
        if(score>=SCORE_THRESHOLD+level) {
            Invoke("NextLevel", delayTime);
        }
    }

    void DisplayScore() 
    {
        scoreText.text = "Score: " + PersistantData.Instance.GetScore();
    }

    void DisplayLevel() 
    {
        levelText.text = "Level: " + (level);
    }

    void DisplayName() 
    {
        playerNameText.text = "Player: " + PersistantData.Instance.GetName();
    }

    void NextLevel() 
    {
        if(level<3)
            SceneManager.LoadScene(level+1);
        else
            SceneManager.LoadScene("HighScores");
    }
}
