using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer = 0;
    public float time = 30;
    public float seconds = 1;
    public TextMeshProUGUI timerText;

    // Update is called once per frame
    void Update()
    {
        // This is a countdown timer that can be influenced by the collectible fish, and is also tied to a game over condition.
            timer += Time.deltaTime;
            if (timer >= seconds)
            {
                time -= 1;
                timer = 0f; // Resets timer
            }
        timerText.text = "Time Left: " + time; // It also gets displayed on the UI using this text.
        
    }
}
