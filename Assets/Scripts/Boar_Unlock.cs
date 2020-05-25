using UnityEngine;

// The Boar Totem script
public class Boar_Unlock : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject boar;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When the player triggers the attached Collider, a Boar is instantiated, and the Totem is destroyed
        if (collision.gameObject.tag == "Player1")
        {
            Transform playerPosition = gameManager.GetPlayerPosition();
            Instantiate(boar, new Vector3(playerPosition.position.x, playerPosition.position.y + 1.3f, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
