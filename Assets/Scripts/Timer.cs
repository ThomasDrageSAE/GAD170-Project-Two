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
        
            timer += Time.deltaTime;
            if (timer >= seconds)
            {
                time -= 1;
                timer = 0f; // Resets timer
            }
        timerText.text = "Time Left: " + time;
        
    }
}
