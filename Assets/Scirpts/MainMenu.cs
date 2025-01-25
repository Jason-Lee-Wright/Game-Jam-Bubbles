using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu 
{
    public GameObject Mainmenu, AskLeave, Options, Credits;


    // Start is called before the first frame update
    void Awake()
    {
        AskLeave.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(false);
    }

    public void PlayGameGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AskIfLeave()
    {
        AskLeave?.SetActive(true);
    }

    public void OpenOptions()
    {
        Options?.SetActive(true);
    }

    public void OpenCredits()
    {
        Credits?.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AreYouSure()
    {

    }
}
