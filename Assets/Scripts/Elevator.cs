using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // posA is the coordinates of the elevator. posB is the destination. elevator is used to track elevator's current position
    private Transform posA, posB, elevator;

    [SerializeField]
    private float speed;

    // Box collider of switch to determine on-off status
    private BoxCollider2D switchCollider;

    private bool on;

    // Point of touch
    private Vector2 worldPoint;

    void Start()
    {
        on = false;

        switchCollider = this.gameObject.transform.Find("Switch").GetComponent<BoxCollider2D>();

        posA = this.gameObject.transform.Find("PointA");

        elevator = this.gameObject.transform.Find("Elevator");

        posB = this.gameObject.transform.Find("PointB");

        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        ToggleSwitch();

        if (on)
        {
            MoveToB();
        }

        else
        {
            MoveToA();
        }
    }

    // Switch should not collide with the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            Physics2D.IgnoreCollision(collision.collider, switchCollider);
        }
    }

    // Move elevator to point B
    private void MoveToB()
    {
        elevator.localPosition = Vector2.MoveTowards(elevator.localPosition, posB.position, speed * Time.deltaTime);
    }

    // Move elevator to point A
    private void MoveToA()
    {
        elevator.localPosition = Vector2.MoveTowards(elevator.localPosition, posA.position, speed * Time.deltaTime);
    }

    // Logic for enabling/disabling elevator
    private void ToggleSwitch()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                worldPoint = Camera.main.ScreenToWorldPoint(touch.position);

                if (switchCollider == Physics2D.OverlapPoint(worldPoint))
                {
                    Debug.Log("Toggled!");
                    on = !on;
                }
            }
        }
    }


}
