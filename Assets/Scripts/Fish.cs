using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Fish : MonoBehaviour
{
    private ScoreManager scoreManager;
    private FishSpawn fishSpawn;
    private Timer timer;
    public AudioClip meow;
    public AudioSource Cat;
    private ParticleSystem smoke;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Here is me cross referencing other scripts as I use their functions within this script.
        scoreManager = FindAnyObjectByType<ScoreManager>();
        fishSpawn = FindAnyObjectByType<FishSpawn>();
        timer = FindAnyObjectByType<Timer>();
        smoke = GetComponent<ParticleSystem>();

        // Here is my check for null to make sure the audio files are assigned.
        if (Cat == null || meow == null)
        {
            Debug.LogWarning("Audio is not assigned!");
        }
    }

    void OnTriggerEnter(Collider fish) // Here is my trigger function so when the player enters the collider for the fish it adds 1 to the score, then plays a sound, heals the player, destroys the object, then spawns a new one somewhere else
        
    {
        if (fish.transform.tag == "Player")
        {
            smoke.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            scoreManager.AddFish(1);
            Cat.PlayOneShot(meow);
            scoreManager.playerHealth += 5;
            timer.time += 5;
            fishSpawn.SpawnFish();
            Destroy(gameObject);
                  
            Debug.Log("Picked up Fish!"); // I have this debug to ensure the collider was working properly.
        }
    }
}
