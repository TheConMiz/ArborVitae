using UnityEngine;

public class Boulder_PressurePlate : MonoBehaviour
{
    private Boulder boulder;

    private void Start()
    {
        boulder = this.gameObject.transform.parent.GetComponent<Boulder>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On collision with the Player1, activate the Boulder.
        if (collision.gameObject.tag == "Player1")
        {
            boulder.SetActiveStatus(true);
        }
    }


}
