using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    private int waterDamage = 5;
    private ScoreManager scoreManager;
    public bool playerInWater = false, isWater = false; // Booleans for if the player is in water and if the water is toggled on or off.
    private float damageTime = 0, damageSeconds = 1; // Timer for damage and Amount of seconds for damage to hit.
    public MeshRenderer meshRenderer;
    public Material water, empty;
    public float seconds = 3, time = 0; // Timer for when the water toggles on and off.

    // Start is called once before the first execution of Update after the MonoBehaviour is created.
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
        if (scoreManager == null) // check for null to make sure the script is assigned.
            Debug.LogError("ScoreManager not found!");
    }

    // Update is called once per frame
    void Update()
    {
        WaterTimer(); // Starts the function for the water toggling, then constanly checks if the player has stepped in water.
        if (playerInWater == true)
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
        if (waterEnter.gameObject.tag == "Player" && isWater == true)
        {
        
            
                Debug.Log("Hit:" + waterEnter.transform.name);
                Debug.Log(playerInWater);
                playerInWater = true;
            
        }
    }
    public void OnTriggerStay(Collider waterStay) // When staying in water, Damage keeps going.
    {
        if (waterStay.gameObject.tag == "Player" && isWater == true)
        {


            Debug.Log("Hit:" + waterStay.transform.name);
            Debug.Log(playerInWater);
            playerInWater = true;

        }
    }

    public void OnTriggerExit(Collider waterExit) // When exiting water, Damage stops.
    {
        if (waterExit.gameObject.tag == "Player")
        {
                Debug.Log("Exit:" + waterExit.transform.name);
                playerInWater = false;
            
        }
    }

    public void WaterTimer() // This toggles the water on and off every 3 seconds.
    {
        time += Time.deltaTime;
        if (time >= seconds && isWater == true)
        {
     
            time = 0f; // Resets timer
            meshRenderer.material = empty;
            isWater = false;
        }

        if (time >= seconds && isWater == false)
        {
            time = 0f; // Resets timer
            meshRenderer.material = water;
            isWater = true;
        }
    }    
}
