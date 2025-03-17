using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSpawn : MonoBehaviour
{
    public GameObject carPrefab;
    private ScoreManager scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCar();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SpawnCar()
    {
        Instantiate(carPrefab, new Vector3(81, 0.35f, -409), Quaternion.identity);
    }
}
