using UnityEngine;

public class Elevator_Switch : MonoBehaviour
{
    private GameObject elevatorSwitch;

    private Elevator elevator;

    private void Start()
    {
        elevatorSwitch = this.gameObject;

        elevator = elevatorSwitch.transform.parent.gameObject.GetComponent<Elevator>();

        SetColor();
    }

    private void Update()
    {
        ToggleSwitch();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player1" || collision.collider.tag == "Barrel" || collision.collider.tag == "Boar")
        {
            Physics2D.IgnoreCollision(collision.collider, elevatorSwitch.GetComponent<BoxCollider2D>());
        }
    }

    // If touched, trigger
    private void ToggleSwitch()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);

                if (touch.phase == TouchPhase.Ended)
                {
                    if (elevatorSwitch.GetComponent<BoxCollider2D>() == Physics2D.OverlapPoint(worldPoint))
                    {
                        if (touch.phase == TouchPhase.Ended)
                        {
                            elevator.Toggle();

                            SetColor();
                        }
                    }
                }
            }
        }
    }

    private void SetColor()
    {
        if (elevator.GetToggleValue())
        {
            elevatorSwitch.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        }

        else
        {
            elevatorSwitch.GetComponent<SpriteRenderer>().color = new Color(97f / 255, 97f / 255, 97f / 255); ;
        }
    }

}
