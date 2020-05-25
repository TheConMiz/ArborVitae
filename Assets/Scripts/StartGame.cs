using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void GameStart()
    {
        // Used to load the Start Screen at the beginning of the game.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
