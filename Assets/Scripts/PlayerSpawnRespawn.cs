using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerSpawnRespawn : MonoBehaviour
{
    private LevelManager levelManager;

    private PlayerManager playerManager;

    private UIManager uiManager;


    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();

        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        transform.position = levelManager.lastCheckpoint;
    }

    void Update()
    {
        // if levelmanager.isalive is false -> enable death ui. Restart does that
        if (!playerManager.isAlive)
        {
            uiManager.Dead();
        }
    }
}
