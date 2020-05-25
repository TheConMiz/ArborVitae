using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{

    public GameObject GameplayUI, PauseUI, DeadUI, VictoryUI;

    private Animator animator;

    private GameManager gameManager;

    // On Start, enable the GamePlayUI and disable all other UIs. 
    void Start()
    {
        PauseUI.SetActive(false);

        GameplayUI.SetActive(true);
        
        DeadUI.SetActive(false);

        VictoryUI.SetActive(false);

        animator = GameObject.FindGameObjectWithTag("Player1").GetComponent<Animator>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // On Pause, enable the PauseUI and set time scale to 0
    public void Pause()
    {
        Time.timeScale = 0;

        PauseUI.SetActive(true);

        GameplayUI.SetActive(false);
    }

    // On Player1 death, enable the DeathUI
    public void Dead()
    {
        animator.SetBool("Dead", true);

        Time.timeScale = 0;

        DeadUI.SetActive(true);

        GameplayUI.SetActive(false);
    }

    // On Resumption, re-enable the GameplayUI.
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

    // On Restart, set time scale to 1, reload the current scene, and re-enable the GamePlayUI.
    public void Restart()
    {
        animator.SetBool("Dead", false);

        gameManager.SetIsAlive(true);

        PauseUI.SetActive(false);

        DeadUI.SetActive(false);

        GameplayUI.SetActive(true);

        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // On victory, enable the VictoryUI.
    public void Victory()
    {
        Time.timeScale = 0;

        VictoryUI.SetActive(true);

        GameplayUI.SetActive(false);
    }
}
