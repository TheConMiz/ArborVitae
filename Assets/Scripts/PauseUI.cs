using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseUI;

    private bool paused = false;

    void Start()
    {
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (paused)
            {
                paused = false;

                pauseUI.SetActive(paused);

                Time.timeScale = 1;
            }

            else
            {
                paused = true;

                pauseUI.SetActive(true);

                Time.timeScale = 0;
            }
        }
    }
}
