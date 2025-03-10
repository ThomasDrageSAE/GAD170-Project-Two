using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    

    public GameObject fishPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnFish();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFish()
    {
        float x = Random.Range(0, 50);
        float y = 1.67f;
        float z = Random.Range(0, 50);
        Instantiate(fishPrefab,new Vector3(x,y,z), Quaternion.identity);
    }
}
