using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    private int waterDamage = 5;
    private ScoreManager scoreManager;
    public bool playerInWater = false;
    private float damageTime = 0; // Timer for damage
    private float damageSeconds = 1; // Amount of seconds for damage to hit

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
        if (scoreManager == null)
            Debug.LogError("ScoreManager not found!");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInWater)
        {
            damageTime += Time.deltaTime;
            if (damageTime >= damageSeconds)
            {
                scoreManager.playerHealth -= waterDamage;
                damageTime = 0f; // Resets timer
            }
        }
    }

    public void OnTriggerEnter(Collider waterEnter) // When entering water, Damage starts.
    {
        Debug.Log("Hit:" + waterEnter.transform.name);
        Debug.Log(playerInWater);
        playerInWater = true;
       
    }

    public void OnTriggerExit(Collider waterExit) // When exiting water, Damage stops.
    {
        Debug.Log("Exit:" + waterExit.transform.name);
        playerInWater = false ;
    }
}
