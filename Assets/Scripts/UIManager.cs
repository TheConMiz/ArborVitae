using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject Canvas;

    public GameObject GameplayUI;
    public GameObject PauseUI;
    public GameObject DeadUI;

    // private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
        GameplayUI.SetActive(true);
        DeadUI.SetActive(false);
    }

    void Update()
    {

    }

    public void Pause()
    {
        Time.timeScale = 0;

        // paused = true;

        PauseUI.SetActive(true);

        GameplayUI.SetActive(false);

    }

    public void Resume()
    {
        // paused = false;

        PauseUI.SetActive(false);

        GameplayUI.SetActive(true);

    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting...");
    }

    public void Restart()
    {
        Debug.Log("Restarting...");
    }

    public void GameStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
        // Time.timeScale = 1;
    }
}
