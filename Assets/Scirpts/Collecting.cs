using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collecting : MonoBehaviour
{
    public GameObject letter_S_col;
    public GameObject letter_S_Ui_off;
    public GameObject letter_S_ui_on;
    public GameObject letter_O_col;
    public GameObject letter_O_ui_off;
    public GameObject letter_O_ui_on;
    public GameObject letter_A_col;
    public GameObject letter_A_ui_off;
    public GameObject letter_A_ui_on;
    public GameObject letter_P_col;
    public GameObject letter_P_ui_off;
    public GameObject letter_P_ui_on;
    [SerializeField] private int score;
    public GameObject endgame;

    void Start()
    {
        letter_S_col.SetActive(true);
        letter_O_col.SetActive(true);
        letter_A_col.SetActive(true);
        letter_P_col.SetActive(true);
        letter_S_Ui_off.SetActive(true);
        letter_O_ui_off.SetActive(true);
        letter_A_ui_off.SetActive(true);
        letter_P_ui_off.SetActive(true);
        letter_S_ui_on.SetActive(false);
        letter_O_ui_on.SetActive(false);
        letter_A_ui_on.SetActive(false);
        letter_P_ui_on.SetActive(false);
        score = 0;
        endgame.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("S"))
        {
            letter_S_col.SetActive(false);
            letter_S_Ui_off.SetActive(false);
            letter_S_ui_on.SetActive(true);
            score++;

            if (other.CompareTag("O"))
            {
                letter_O_col.SetActive(false);
                letter_O_ui_off.SetActive(false);
                letter_O_ui_on.SetActive(true);
                score++;

                if (other.CompareTag("A"))
                {
                    letter_A_col.SetActive(false);
                    letter_A_ui_off.SetActive(false);
                    letter_A_ui_on.SetActive(true);
                    score++;

                    if (other.CompareTag("P"))
                    {
                        letter_P_col.SetActive(false);
                        letter_P_ui_off.SetActive(false);
                        letter_P_ui_on.SetActive(true);
                        score++;
                    }
                    else
                    {
                        other.gameObject.SetActive(false);
                        Res();
                    }
                }
                else
                {
                    other.gameObject.SetActive(false);
                    Res();
                }

            }

            else
            {
                other.gameObject.SetActive(false);
                Res();

            }

        }
        else
        {
            other.gameObject.SetActive(false);
            Res();
        }
    }

    public void Res()
    {

        letter_S_col.SetActive(true);
        letter_O_col.SetActive(true);
        letter_A_col.SetActive(true);
        letter_P_col.SetActive(true);
        score = 0;
    }

    private void Update()
    {
        if (score == 4)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            endgame.SetActive(true);
            letter_S_ui_on.SetActive(false);
            letter_O_ui_on.SetActive(false);
            letter_A_ui_on.SetActive(false);
            letter_P_ui_on.SetActive(false);


        }
    }

}
