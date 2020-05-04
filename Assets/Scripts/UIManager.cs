using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject Canvas;

    public GameObject GameplayUI, PauseUI, DeadUI;

    private Animator animator;

    private PlayerManager playerManager;



    void Start()
    {
        PauseUI.SetActive(false);

        GameplayUI.SetActive(true);
        
        DeadUI.SetActive(false);

        animator = GameObject.FindGameObjectWithTag("Player1").GetComponent<Animator>();

        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
    }

    public void Pause()
    {
        Time.timeScale = 0;

        PauseUI.SetActive(true);

        GameplayUI.SetActive(false);
    }

    public void Dead()
    {
        Time.timeScale = 0;

        DeadUI.SetActive(true);

        animator.SetBool("Dead", true);

        GameplayUI.SetActive(false);
    }

    public void Resume()
    {
        PauseUI.SetActive(false);

        GameplayUI.SetActive(true);

        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        animator.SetBool("Dead", false);

        playerManager.isAlive = true;

        PauseUI.SetActive(false);

        DeadUI.SetActive(false);

        GameplayUI.SetActive(true);

        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
