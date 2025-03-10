using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public int fish = 0;
    public int playerHealth = 100;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;


    void Start()
    {

    }
    void Update()
    {
        healthText.text = "health: " + playerHealth;
        //Win Condition
        if (fish == 15)
        {

        }
        //Loss Condition
        if (playerHealth >= 0)
        {

        }
    }

    public void AddFish(int score)
    {
        fish += score;
        scoreText.text = "Fish: " + fish;
    }
}
