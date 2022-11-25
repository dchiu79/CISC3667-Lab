using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTracker : MonoBehaviour
{
    public const int NUM_HIGH_SCORES = 5;
    public const string NAME_KEY = "HSNameKey";
    public const string SCORE_KEY = "HSScoreKey";
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] Text[] nameTexts;
    [SerializeField] Text[] scoreTexts;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = PersistantData.Instance.GetScore();
        playerName = PersistantData.Instance.GetName();
        SaveScore();
        ShowScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveScore() 
    {
        for(int i=0;i<NUM_HIGH_SCORES;i++) 
        {
            string currentNameKey = NAME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;

            if(PlayerPrefs.HasKey(currentScoreKey)) 
            {
                int currentScore = PlayerPrefs.GetInt(currentScoreKey);
                if(playerScore>currentScore) 
                {
                    string tempName = PlayerPrefs.GetString(currentNameKey);
                    int tempScore = currentScore;
                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetInt(currentScoreKey, playerScore);
                    playerName = tempName;
                    playerScore = tempScore;
                }
            }
            else 
            {
                PlayerPrefs.SetString(currentNameKey, playerName);
                PlayerPrefs.SetInt(currentScoreKey, playerScore);
                return;
            }
        }
    }

    void ShowScore() 
    {
        for(int i=0;i<NUM_HIGH_SCORES;i++) 
        {
            nameTexts[i].text = PlayerPrefs.GetString(NAME_KEY+i);
            scoreTexts[i].text = PlayerPrefs.GetInt(SCORE_KEY+i).ToString();
        }
    }
}
