using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Fall : MonoBehaviour
{
    private Rigidbody2D barrelRigidBody;

    private void Start()
    {
        barrelRigidBody = this.gameObject.GetComponentInParent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground") && barrelRigidBody.velocity.y < -10f)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}
