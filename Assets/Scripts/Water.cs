using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    private int waterDamage = 3;
    private ScoreManager scoreManager;
    public bool playerInWater = false;
    private float damageTime = 0; // Timer for damage
    private float damageSeconds = 1; // Amount of seconds for damage to hit
    public MeshRenderer meshRenderer;
    public Material water;
    public Material empty;
    public bool isWater = false;
    public float seconds = 3;
    public float time = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
        if (scoreManager == null)
            Debug.LogError("ScoreManager not found!");
    }

    // Update is called once per frame
    void Update()
    {
        WaterTimer();
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
        if (isWater)
        {
            Debug.Log("Hit:" + waterEnter.transform.name);
            Debug.Log(playerInWater);
            playerInWater = true;
        }
    }

    public void OnTriggerExit(Collider waterExit) // When exiting water, Damage stops.
    {
        if (isWater)
        {
            Debug.Log("Exit:" + waterExit.transform.name);
            playerInWater = false;
        }
    }

    public void WaterTimer()
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
