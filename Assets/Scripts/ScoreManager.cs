using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class ScoreManager : MonoBehaviour
{

    public int fish = 0;
    public int playerHealth = 100;
    public TextMeshProUGUI scoreText, healthText, tipText;
    private Water water;
    private Timer timer;
    private Car car;
    public GameObject gameOverScreen, gameWinScreen, tutorialScreen, clockImage, carImage, waterCatImage;
    public AudioClip nyan;
    public AudioSource gameMusic;


    void Start()
    {
        healthText.text = "Health: " + playerHealth;
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

    public void GameOver()
    {

        if (water.playerInWater == true)
        {
            gameOverScreen.SetActive(true);
            tipText.text = "Cats Don't Like Water!"; // This is game over text that can be interchanged depending on certain conditions, for this one it only comes up if the player is in water.
        }

        else
        {
            gameOverScreen.SetActive(true);
            carImage.SetActive(true);
            tipText.text = "Watch Out For Cars!"; // And this one happens if hit by a car.
        }  
    }
}
