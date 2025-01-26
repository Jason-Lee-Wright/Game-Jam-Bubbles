using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;   // Timer text to display countdown
    [SerializeField] float remainingTime;          // The total time for the main countdown
    public TextMeshProUGUI textObject;             // "Time's up!" text object
    public GameObject EndMe;

    void Awake()
    {
        timerText.text = "";  // Clear the timer text at the start
    }

    void Start()
    {
        // Start the start countdown sequence (3, 2, 1, Go!)
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        int startTime = 3;

        // Countdown 3, 2, 1
        while (startTime > 0)
        {
            timerText.text = startTime.ToString();
            yield return new WaitForSeconds(1);
            startTime--;
        }

        // Display "Go!" after countdown
        timerText.text = "Go!";
        yield return new WaitForSeconds(1);
        timerText.text = ""; // Clear "Go!" message

        // Start the main countdown after "Go!" disappears
        StartCoroutine(CountdownMethod());
    }

    // Main countdown method
    IEnumerator CountdownMethod()
    {
        // Set the initial timer text to the full time (minutes:seconds)
        UpdateTimerText();

        // Start the main countdown loop
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime; // Decrease remaining time

            // Update the timer display
            UpdateTimerText();

            // Wait until the next frame
            yield return null;
        }

        // Timer has reached zero, show "Time's up!"
        timerText.text = "Time's up!";
        
        // Wait for 3 seconds before destroying the textObject
        yield return new WaitForSeconds(3);

        // Destroy the text object (e.g., hide the "Time's up!" message)
        Destroy(textObject.gameObject); // Use `textObject.gameObject` to destroy the entire GameObject
        EndMe.SetActive(true);
    }

    // Helper method to update the timer text in minutes:seconds format
    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}