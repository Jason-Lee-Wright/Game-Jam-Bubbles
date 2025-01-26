using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Mainmenu, AskLeave, Credits;


    // Start is called before the first frame update
    void Awake()
    {
        AskLeave.SetActive(false);
        Credits.SetActive(false);
    }

    public void PlayGameGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AskIfLeave()
    {
        AskLeave?.SetActive(true);
        Mainmenu.SetActive(false);
    }

    public void OpenCredits()
    {
        Credits?.SetActive(true);
        Mainmenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DontQuit()
    {
        AskLeave.SetActive(false);
        Mainmenu.SetActive(true);
    }

    public void NOODLES()
    {
        Mainmenu.SetActive(true);
        Credits.SetActive(false);
    }
}