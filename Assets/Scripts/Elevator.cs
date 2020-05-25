using UnityEngine;

public class Elevator : MonoBehaviour
{
    private Transform posA, posB, elevator;

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool on;


    void Start()
    {
        on = false;

        posA = this.gameObject.transform.Find("PointA");

        elevator = this.gameObject.transform.Find("Sprite");

        posB = this.gameObject.transform.Find("PointB");

        speed = 3f;
    }

    void Update()
    {
        // If on, move towards Point B. Else, move towards Point A.
        if (on)
        {
            MoveToB();
        }

        else
        {
            MoveToA();
        }

    }

    private void MoveToA()
    {
        // Move the Elevator towards Point A
        elevator.localPosition = Vector2.MoveTowards(elevator.localPosition, posA.localPosition, speed * Time.deltaTime);
    }

    private void MoveToB()
    {
        // Move the Elevator towards Point B
        elevator.localPosition = Vector2.MoveTowards(elevator.localPosition, posB.localPosition, speed * Time.deltaTime);
    }


    public void Toggle()
    {
        // To be used by the Elevator Switch. Toggles the direction in which the Elevator moves.
        on = !on;
    }

    public bool GetToggleValue()
    {
        return on;
    }
}
