using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Fish : MonoBehaviour
{
    private ScoreManager scoreManager;
    private FishSpawn fishSpawn;
    public AudioClip meow;
    public AudioSource Cat;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
        fishSpawn = FindAnyObjectByType<FishSpawn>();

        if (Cat == null || meow == null)
        {
            Debug.LogWarning("Audio is not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider fish)
    {
        if (fish.transform.tag == "Player")
        {
            scoreManager.AddFish(1);
            Cat.PlayOneShot(meow);
            scoreManager.playerHealth += 5;
            Destroy(gameObject);
            fishSpawn.SpawnFish();       
            Debug.Log("Picked up Fish!");
        }
    }
}
