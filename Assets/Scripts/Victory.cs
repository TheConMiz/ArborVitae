using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    private UIManager uiManager;

    private GameManager gameManager;

    [SerializeField]
    private Vector2 firstCheckpoint;

    private void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On collision with the Player1, invoke the UIManager to handle player victory.
        if (collision.gameObject.tag == "Player1")
        {
            gameManager.SetLastCheckpoint(firstCheckpoint);

            uiManager.Victory();
        }
    }
}
