using UnityEngine;

public class Boulder_Sprite : MonoBehaviour
{
    private Boulder boulder;

    private Transform player1;

    private void Start()
    {
        boulder = this.gameObject.transform.parent.GetComponent<Boulder>();

        player1 = GameObject.FindGameObjectWithTag("Player1").transform;
    }

    private void Update()
    {
        // The Boulder only moves if it has been activated by the switch.
        if (boulder.GetIsActive())
        {
            // Apply a rightward impulse force to the Boulder if the player is to the right of the Boulder.
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            if (player1.position.x > this.gameObject.transform.position.x)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 0f), ForceMode2D.Impulse);
            }
            // Apply a leftward impulse force to the Boulder if the player is to the left of the Boulder.
            if (player1.position.x < this.gameObject.transform.position.x)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, 0f), ForceMode2D.Impulse);
            }
        }

        // If inactive, it is unable to move in the X and Z directions.
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On collision with Boars, the Boulder is destroyed
        if (collision.collider.tag == "Boar")
        {
            Destroy(this.gameObject, .5f);
        }

        // On collision with other Boulders, the Boulder is allowed to move freely.
        if (collision.collider.tag == "Boulder")
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }

        // On collision with the Player1 object, the Boulder only kills it if travelling at a velocity greater than 4 units in any direction.
        if (Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x) > 4f)
        {
            if (collision.collider.tag == "Player1")
            {
                boulder.KillPlayer();

                boulder.SetActiveStatus(false);
            }
        }
    }
}
