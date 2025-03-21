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
    public Timer timer;
    public GameObject gameOverScreen;
    public GameObject tutorialScreen;
    public GameObject clock;
    public GameObject car;
    public GameObject waterCat;
    public AudioClip nyan;
    public AudioSource gameMusic;


    void Start()
    {
        water = FindAnyObjectByType<Water>();
        timer = FindAnyObjectByType<Timer>();
        gameMusic.PlayOneShot(nyan);
    }
    void Update()
    {
        healthText.text = "Health: " + playerHealth;

        //Win Condition, If the player collects 10 fish, a separate canvas acting as a win screen is turned on.
        if (fish >= 15)
        {
            gameWinScreen.SetActive(true);
        }

        // Loss Condition, If the player health is 0 or below a canvas acting as a game over screen is turned on
        if (playerHealth == 0)
        {
            gameOverScreen.SetActive(true);

            if (water.playerInWater == true)
            {
                Debug.Log(water.playerInWater);
                waterCat.SetActive(true);
                helpfullTipText.text = "Cats Don't Like Water!"; // This is text that can be interchanged depending on certain conditions, for this one it only comes up if the player is in water.

            }

            else
            {
                car.SetActive(true);
                helpfullTipText.text = "Watch Out For Cars!"; // And as the only other danger is cars I just put the other text in this else statement.
            }


        }
        if (timer.time <= 0)
        {
            gameOverScreen.SetActive(true);
            clock.SetActive(true); // This is for a clock image that comes up.
            helpfullTipText.text = "You Ran Out of Time!"; // This game over screen happens when the timer runs out.
        }
    }

    public void AddFish(int score) // This is my function for adding fish to the UI.
    {
        fish += score;
        scoreText.text = "Fish: " + fish;
    }

    public void RestartButton() // Here is my button that comes up on win or loss to restart the game.
    {
        SceneManager.LoadScene(1);
    }
    public void StartButton() // Here is my button that comes up on the tutorial screen to start the game.
    {
        tutorialScreen.SetActive(false);
    }
}
