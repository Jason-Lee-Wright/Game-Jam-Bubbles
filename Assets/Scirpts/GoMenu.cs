using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMenu : MonoBehaviour
{
    private int jumpscenes;

    public void GO()
    {
        Debug.Log("Go");
        SceneManager.LoadScene("Main Menu");
    }
}
