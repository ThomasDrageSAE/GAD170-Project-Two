using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public int fish = 0;
    public int playerHealth = 100;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject gameWinScreen;
    public TextMeshProUGUI helpfullTipText;
    private Water water;
    public GameObject gameOverScreen;
    public AudioClip nyan;
    public AudioClip ff7;
    public AudioSource gameMusic;

    void Start()
    {
        water = FindAnyObjectByType<Water>();
        gameMusic.PlayOneShot(nyan);
    }
    void Update()
    {
        healthText.text = "health: " + playerHealth;
        //Win Condition
        if (fish == 10)
        {
            gameWinScreen.SetActive(true);
        }

        if (playerHealth <= 0)
        {
            gameOverScreen.SetActive(true);

            if (water.playerInWater == true)
            {
                Debug.Log(water.playerInWater);
                helpfullTipText.text = "Cats don't like water!";
         
            }
            else
            {
                helpfullTipText.text = "Watch out for cars!";
            }
            
            
        }

    }

    public void AddFish(int score)
    {
        fish += score;
        scoreText.text = "Fish: " + fish;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
