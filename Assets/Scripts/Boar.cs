using UnityEngine;

public class Boar : MonoBehaviour
{
    // This represents the duration for which the Boar remains active. By defau;t, this is set to 15 seconds.
    [SerializeField]
    private float timer;

    // Reference to the GameManager script
    private GameManager gameManager;

    private void Start()
    {
        timer = 15f;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        // References to the required components
        Transform playerPosition = gameManager.GetPlayerPosition();
        Vector3 tempScale = this.gameObject.transform.localScale;
        Vector3 playerScale = gameManager.GetPlayerScale();
        Rigidbody2D playerRigidBody = gameManager.GetPlayerRigidBody();

        // The Boar adheres itself to the Player1 object at all times. 
        this.gameObject.transform.position = new Vector3(playerPosition.position.x, playerPosition.position.y + 1.3f, 0f);
        
        // The localScale of the Boar is modified to allow it to turn based on the Player1 object's movement
        if ((playerScale.x < 0f && tempScale.x >= 0f) || (playerScale.x >= 0f && tempScale.x < 0f))
        {
            tempScale.x *= -1;

            this.gameObject.transform.localScale = tempScale;
        }

        // This is used to look at Player1's current movement speed. The Boar's animation is toggled based on the player's movement speed
        if (Mathf.Abs(playerRigidBody.velocity.x) <= 0.1f && Mathf.Abs(playerRigidBody.velocity.y) <= 0.1f)
        {
            this.gameObject.GetComponent<Animator>().speed = 0f;
        }
        else
        {
            this.gameObject.GetComponent<Animator>().speed = 1f;
        }

        // At the end of the timed interval, the Boar is destoyed.
        Destroy(this.gameObject, timer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // The Boar ignores any collisions with Player1
        if (collision.collider.tag == "Player1")
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }

        // An impulse is applied to oncoming Boulders.
        if (collision.collider.tag == "Boulder")
        {
            collision.rigidbody.AddForce(new Vector2(1000f, 2000f), ForceMode2D.Impulse);
        }

        // UNUSED: Fires are destroyed by boulders.
        if (collision.collider.tag == "Fire")
        {
            Destroy(this.gameObject, 0.1f);
        }
    }
}
