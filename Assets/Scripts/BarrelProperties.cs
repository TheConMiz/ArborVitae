using UnityEngine;
using UnityEngine.EventSystems;

public class BarrelProperties : MonoBehaviour
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
        if (Input.touchCount > 0) 
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                if (boxCollider == Physics2D.OverlapPoint(worldPoint) || circleCollider == Physics2D.OverlapPoint(worldPoint))
                {
                    rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                if (boxCollider == Physics2D.OverlapPoint(worldPoint) || circleCollider == Physics2D.OverlapPoint(worldPoint))
                {
                    Debug.Log("HIT out");

                    rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                }
            }


        }


    }
}
