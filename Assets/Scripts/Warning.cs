using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public TextMeshProUGUI warningText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }
    public void OnTriggerEnter(Collider warning) // When entering water, Damage starts.
    {
        if (warning.gameObject.tag == "Player")
        {
            warningText.text = "Watch out for the water squares!!!";


        }
    }
    public void OnTriggerExit(Collider warning) // When entering water, Damage starts.
    {
        if (warning.gameObject.tag == "Player")
        {
            warningText.text = "";
            Destroy(gameObject);
        }
    }
}
