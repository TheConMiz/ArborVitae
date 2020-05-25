using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Transform cameraPosition;

    // Length and starting position of sprite
    private float length, startPos;

    [SerializeField]
    private float parallaxStrength;

    private void Start()
    {
        cameraPosition = GameObject.FindGameObjectWithTag("MainCamera").transform;

        length = this.transform.GetComponent<SpriteRenderer>().bounds.size.x;

        this.transform.position = new Vector3(cameraPosition.position.x, cameraPosition.position.y, 100f);
    }

    private void FixedUpdate()
    {
        float temp = cameraPosition.transform.position.x * (1 - parallaxStrength);

        float distance = cameraPosition.transform.position.x * parallaxStrength;

        this.transform.position = new Vector3(startPos + distance, this.transform.position.y, 90f);

        if (temp > startPos)
        {
            startPos += length;
        }

        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
