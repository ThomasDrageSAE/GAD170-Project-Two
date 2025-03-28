using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public int carDamage = 50;
    private ScoreManager scoreManager;
    public bool carContact = false;
    public bool isCarSpawned = false;
 
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
        Destroy(gameObject, 8); // 8 seconds after spawning the car gets destroyed
    }

    public void OnTriggerEnter(Collider car) // This is applied to the cars and detects when player is entering the collider.
    {
        Debug.Log("Hit:" + car.transform.name); // This is my debug to make sure it was working.
        if (car.gameObject.tag == "Player")
        {
            carContact = true;
            Debug.Log("Hit Car!");
            scoreManager.playerHealth -= carDamage;
            scoreManager.healthText.text = "Health: " + scoreManager.playerHealth;
            
            if (scoreManager.playerHealth <= 0 )
            {
                scoreManager.GameOver();
            }    
        }
    }
    public void OnTriggerExit(Collider car) 
    {
        if (car.gameObject.tag == "Player")
        {
            carContact = false;
            Debug.Log(carContact);
        }
    }
}
