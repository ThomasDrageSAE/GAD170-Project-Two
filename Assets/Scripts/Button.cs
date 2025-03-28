using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void RestartButton() // Here is my button that comes up on win or loss to restart the game.
    {
        SceneManager.LoadScene(0);
    }
    public void StartButton() // Here is my button that comes up on the tutorial screen to start the game.
    {
        SceneManager.LoadScene(1);
    }
}
