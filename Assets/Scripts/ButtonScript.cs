using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject[] pauseMode;
    [SerializeField] GameObject[] resumeMode;
    [SerializeField] InputField playerNameInput;
    // Start is called before the first frame update
    void Start()
    {
        if(playerNameInput!=null)
            playerNameInput.text = PersistantData.Instance.GetName();
        pauseMode = GameObject.FindGameObjectsWithTag("ShowOnPause");
        resumeMode = GameObject.FindGameObjectsWithTag("ShowOnResume");
        foreach (GameObject g in pauseMode)
            g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() 
    {
        string name = playerNameInput.text;
        PersistantData.Instance.SetName(name);
        SceneManager.LoadScene(1);
    }
    
    public void Instructions() 
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Settings() 
    {
        SceneManager.LoadScene("Settings");
    }

    public void Menu() 
    {
        SceneManager.LoadScene("Menu");
    }

    public void HighScores() 
    {
        SceneManager.LoadScene("HighScores");
    }

    public void Pause() 
    {
        Time.timeScale = 0.0f;
        foreach (GameObject g in pauseMode)
            g.SetActive(true);
        foreach (GameObject g in resumeMode)
            g.SetActive(false);
    }

    public void Resume() 
    {
        Time.timeScale = 1.0f;
        foreach (GameObject g in pauseMode)
            g.SetActive(false);
        foreach (GameObject g in resumeMode)
            g.SetActive(true);
    }
}
