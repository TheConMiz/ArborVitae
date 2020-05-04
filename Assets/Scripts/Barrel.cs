using UnityEngine;
using UnityEngine.EventSystems;

public class Barrel : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private BoxCollider2D boxCollider;

    private CircleCollider2D circleCollider;

    private Vector2 worldPoint;

    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
        circleCollider = this.gameObject.GetComponent<CircleCollider2D>();

        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Problem: if finger leaves barrel whilst moving, x movement stays on
        // Solution - Reset camera to disallow this possibility
        if (Input.touchCount > 0) 
        {
            foreach(Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    worldPoint = Camera.main.ScreenToWorldPoint(touch.position);

                    if (boxCollider == Physics2D.OverlapPoint(worldPoint) || circleCollider == Physics2D.OverlapPoint(worldPoint))
                    {
                        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                    }

                }

                if (touch.phase == TouchPhase.Ended)
                {
                    worldPoint = Camera.main.ScreenToWorldPoint(touch.position);

                    if (boxCollider == Physics2D.OverlapPoint(worldPoint) || circleCollider == Physics2D.OverlapPoint(worldPoint))
                    {
                        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                    }
                }
            }
        }


    }
}
