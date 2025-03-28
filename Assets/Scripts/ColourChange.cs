using UnityEngine;
using UnityEngine.SceneManagement;

public class ColourChange : MonoBehaviour
{
    public bool isBlue = false;
    public Material blue;
    public Material green;
    public MeshRenderer meshRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

        private void OnCollisionEnter(Collision cube) // This is applied to the cube and detects when player is entering the collider. Then toggles the colours
    {
        Debug.Log("Change colour:" ); // This is my debug to make sure it was working.
        if (cube.gameObject.tag == "Player")
        {
            if (isBlue == true)
            {
                meshRenderer.material = green;
                // Swap to green  
                isBlue = false;
                meshRenderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }
            else
            {
                meshRenderer.material = blue;
                // Swap to blue
                isBlue = true;
                meshRenderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }
        }
    }
    
}
