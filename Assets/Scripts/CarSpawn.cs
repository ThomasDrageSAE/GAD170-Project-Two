using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSpawn : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject carPrefab2;
    private ScoreManager scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCar();

    }

    public void SpawnCar() // Here is my function for spawning the cars, Unlike the fish I dont want this to be random and is in a fixed position.
    {
        Instantiate(carPrefab, new Vector3(81, 0, -409), Quaternion.identity);
        // Instantiate(carPrefab2, new Vector3(139, 0, 1056), new Quaternion(0, 180, 0, 0)); // Here I had to adjust the quarternion as the car is in the other lane. At first it wasnt working but then I realised I forgot the the W dimension.
    }
}
