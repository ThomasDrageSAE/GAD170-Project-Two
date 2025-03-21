using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public int carDamage = 50;
    private ScoreManager scoreManager;
 
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    public void OnTriggerEnter(Collider car) // This is applied to the cars and detects when player is entering the collider.
    {
        Debug.Log("Hit:" + car.transform.name); // This is my debug to make sure it was working.
        if (car.gameObject.tag == "Player")
        {
            scoreManager.playerHealth -= carDamage;
        }
    }
}
