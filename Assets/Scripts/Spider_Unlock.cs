using UnityEngine;

// The Spider Totem Script
public class Spider_Unlock : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject spider;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When the player triggers the attached Collider, a Spider is instantiated, and the Totem is destroyed.

        if (collision.gameObject.tag == "Player1")
        {
            Transform playerPosition = gameManager.GetPlayerPosition();

            Instantiate(spider, new Vector3(playerPosition.position.x, playerPosition.position.y, 0), Quaternion.identity);

            Destroy(this.gameObject);

        }


    }
}
