using UnityEngine;

// Defines checkpoint behaviour for individual checkpoints
public class Checkpoint : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On collision, this object's position in the world is set as the Player1's most recent checkpoint. 
        if (collision.CompareTag("Player1"))
        {
            gameManager.SetLastCheckpoint(transform.position);
        }
    }
}
