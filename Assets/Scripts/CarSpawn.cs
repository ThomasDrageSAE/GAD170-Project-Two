using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSpawn : MonoBehaviour
{
    public GameObject carPrefab, carPrefab2;
    private Car car;
    public float spawnTime = 0, spawnSeconds = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        car = FindAnyObjectByType<Car>();
    }
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= spawnSeconds)
        {
            // This spawns cars at the two coordinates after 5 seconds, then resets the timer and spawns again.
            Instantiate(carPrefab, new Vector3(386.4f, 1, -16.6f), Quaternion.identity);
            Instantiate(carPrefab2, new Vector3(-549, 1, -112.5f), new Quaternion(0, 90, 0, 0));
            spawnTime = 0f; // Resets timer
        }
    }
}
