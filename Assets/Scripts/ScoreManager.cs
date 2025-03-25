using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class ScoreManager : MonoBehaviour
{

    public int fish = 0;
    public int playerHealth = 100;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject gameWinScreen;
    public TextMeshProUGUI tipText;
    private Water water;
    private Timer timer;
    private Car car;
    public GameObject gameOverScreen;
    public GameObject tutorialScreen;
    public GameObject clockImage;
    public GameObject carImage;
    public GameObject waterCatImage;
    public AudioClip nyan;
    public AudioSource gameMusic;


    void Start()
    {
        water = FindAnyObjectByType<Water>();
        timer = FindAnyObjectByType<Timer>();
        car = FindAnyObjectByType<Car>();
        gameMusic.PlayOneShot(nyan);
    }
    void Update()
    {
        healthText.text = "Health: " + playerHealth;

        //Win Condition, If the player collects 15 fish, a separate canvas acting as a win screen is turned on.
        if (fish >= 15)
        {
            gameWinScreen.SetActive(true);
        }

        // Loss Condition, If the player health is 0 or below a canvas acting as a game over screen is turned on
        if (playerHealth <= 0)
        {
            GameOver();
        }
        if (timer.time <= 0)
        {
            gameOverScreen.SetActive(true);
            clockImage.SetActive(true); // This is for a clock image that comes up.
            tipText.text = "You Ran Out of Time!"; // This game over screen and text happens when the timer runs out.
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
    private void GameOver()
    {
        gameOverScreen.SetActive(true);

        if (water.playerInWater == true)
        {
            tipText.text = "Cats Don't Like Water!"; // This is game over text that can be interchanged depending on certain conditions, for this one it only comes up if the player is in water.
        }

        if (car.carContact == true)
        {
            carImage.SetActive(true);
            tipText.text = "Watch Out For Cars!"; // And as the only other danger is cars I put the other text in this else statement.
        }  
    }
}
