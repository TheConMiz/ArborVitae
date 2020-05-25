using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;

    void Start()
    {
        // The required components are initialised
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
        circleCollider = this.gameObject.GetComponent<CircleCollider2D>();

        // By default, Barrels are unable to move in the X and Z directions.
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On collision with Boulders, the Barrel is destroyed.
        if (collision.collider.tag == "Boulder")
        {
            Invoke("DestroyBarrel", .1f);
        }

        // On collision with Fires, the Barrel is destroyed.
        // NOTE: The size of the Barrel's Colliders may prevent this statement from being invoked.
        if (collision.collider.tag == "Fire")
        {
            Invoke("DestroyBarrel", .1f);
        }
    }

    private void DestroyBarrel()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        if (Input.touchCount > 0) 
        {
            foreach(Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);

                    // Barrels can only be moved if the player touches and holds their finger over the Barrel.
                    if (boxCollider == Physics2D.OverlapPoint(worldPoint) || circleCollider == Physics2D.OverlapPoint(worldPoint))
                    {
                        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);

                    if (boxCollider == Physics2D.OverlapPoint(worldPoint) || circleCollider == Physics2D.OverlapPoint(worldPoint))
                    {
                        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                    }
                }
            }
        }
    }
}
