using UnityEngine;

public class Fire : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barrel")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y < -5f)
            {
                Debug.Log("Falling barrel");

                Destroy(this.gameObject, .3f);
            }

            else
            {
                Destroy(this.gameObject, .4f);
            }
        }

        if (collision.gameObject.tag == "Player1")
        {
            gameManager.SetIsAlive(false);
        }
    }
}
