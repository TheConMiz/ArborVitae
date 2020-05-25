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
        // If let to fall from a significant height, the Barrel will be destroyed.
        if (collision.gameObject.tag.Equals("Ground") && barrelRigidBody.velocity.y < -20f)
        {
            Destroy(this.transform.parent.gameObject);
        }

        // If let to fall from a small height onto a Fire, the Barrel will be destroyed.
        if (collision.gameObject.tag.Equals("Fire") && barrelRigidBody.velocity.y < -1f)
        {
            Destroy(this.transform.parent.gameObject, .5f);
        }
    }
}
