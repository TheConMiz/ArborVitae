using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Sprite : MonoBehaviour
{
    // On collision entry with Player1 or Barrels, make them children of this object to allow them to move alongside without issues.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player1" || collision.collider.tag == "Barrel")
        {
            collision.collider.transform.SetParent(this.gameObject.transform);
        }
    }

    // On collision exit, revoke childhood of Player1 and Barrel.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player1" || collision.collider.tag == "Barrel")
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
