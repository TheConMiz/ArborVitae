using UnityEngine;

public class Launcher_Fireball : MonoBehaviour
{
    private Transform destination;

    private GameManager gameManager;

    private void Start()
    {
        destination = this.transform.parent.Find("PointB");

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {

        float speed = gameObject.transform.parent.GetComponent<Launcher>().GetSpeed();

        this.transform.localPosition = Vector2.MoveTowards(this.transform.localPosition, destination.localPosition, speed * Time.deltaTime);

        if (this.transform.localPosition == destination.localPosition)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            gameManager.SetIsAlive(false);
            Destroy(this.gameObject, .5f);
        }

        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Hit ground");
            Destroy(this.gameObject);
        }
    }
}
