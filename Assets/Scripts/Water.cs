using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    private int waterDamage = 20;
    public ScoreManager scoreManager;
    public bool playerInWater = false;
    private float damageTime = 0; // Timer for damage
    private float damageSeconds = 1; // Amount of seconds for damage to hit
 
 
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
        if (scoreManager == null)
            Debug.LogError("ScoreManager not found!");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInWater) // This asks the boolean from another script and if true it deals water damage (which is 5) every second, After discussing with Mark I did some research on Time.deltatime as before it was dealing damage every frame.
        {
            damageTime += Time.deltaTime;
            if (damageTime >= damageSeconds)
            {
                scoreManager.playerHealth -= waterDamage;
                damageTime = 0f; // Resets timer
            }
        }
    }

    public void OnCollisionEnter(Collision waterEnter) // When entering water, Damage starts. I know this should be a trigger/collider, but as I already have examples of those I put this as collision to show another.
    {
        Debug.Log("Hit:" + waterEnter.transform.name);
        if (waterEnter.gameObject.tag == "Player")
        {
            scoreManager.playerHealth -= waterDamage;
            playerInWater = true; // Here is my boolean that says the player is in the water.
        }
    }

    public void OnCollisionExit(Collision waterExit) // When exiting water, Damage stops.
    {
        Debug.Log("Exit:" + waterExit.transform.name);
        if (waterExit.gameObject.tag == "Player")
        {
            playerInWater = false; // Here is my boolean that says the player is not in the water.
        }
    }
}
