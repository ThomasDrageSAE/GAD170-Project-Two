using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    private int waterDamage = 10;
    private int waterStayDamage = 1;
    public ScoreManager scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision water)
    {
        Debug.Log("Hit:" + water.transform.name);
        if (water.gameObject.tag == "Player")
        {
            scoreManager.playerHealth -= waterDamage; 
        }
    }

    private void OnCollisionStay(Collision waterStay)
    {
        Debug.Log("Hit:" + waterStay.transform.name);
        if (waterStay.gameObject.tag == "Player")
        {
            scoreManager.playerHealth -= waterStayDamage;
        }
    }
}
