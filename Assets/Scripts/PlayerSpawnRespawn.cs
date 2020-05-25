using UnityEngine;

public class PlayerSpawnRespawn : MonoBehaviour
{
    private GameManager gameManager;
    private UIManager uiManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        transform.position = gameManager.GetLastCheckpoint();
    }

    void Update()
    {
        // Invoke the function responsible for killing the Player1 object when the GameManager sets its Alive status to False.
        if (!gameManager.GetIsAlive())
        {
            uiManager.Dead();
        }
    }
}
