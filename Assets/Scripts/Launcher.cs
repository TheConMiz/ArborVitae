using UnityEngine;

public class Launcher : MonoBehaviour
{
    private Transform posA, posB;

    public GameObject projectile;


    [SerializeField]
    private float speed, interval, delay;

    private void Start()
    {
        posA = this.gameObject.transform.Find("PointA");
        posB = this.gameObject.transform.Find("PointB");
        
        // With a delay, and at each interval, invoke the ShootFireball function.
        InvokeRepeating("ShootFireball", delay, interval);

    }

    private void ShootFireball()
    {
        // Instantiate a Fireball at PointA, and make it a child of this Launcher object
        GameObject newFireBall = Instantiate(projectile, new Vector3(posA.position.x, posA.position.y, 0f), Quaternion.identity);

        newFireBall.transform.parent = this.gameObject.transform;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
