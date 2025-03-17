using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public int carDamage = 50;
    private ScoreManager scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision car)
    {
        Debug.Log("Hit:" + car.transform.name);
        if (car.gameObject.tag == "Player")
        {
            scoreManager.playerHealth -= carDamage;
        }
    }
}
