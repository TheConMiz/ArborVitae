using UnityEngine;

public class Hazard : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On collision with a Player1, its Alive status is set to False.
        if (collision.GetComponent<Collider2D>().tag == "Player1")
        {
            gameManager.SetIsAlive(false);
        }
    }
}
