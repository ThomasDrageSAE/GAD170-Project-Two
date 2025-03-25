using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    

    public GameObject fishPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnFish();
    }

    public void SpawnFish() // Function that spawns a collectible fish, y is fixed to a certain height and x and z is a random range.
    {
        float x = Random.Range(-50,100);
        float y = 1.67f;
        float z = Random.Range(-50,100);

        Instantiate(fishPrefab,new Vector3(x,y,z), Quaternion.identity);
    }
}
