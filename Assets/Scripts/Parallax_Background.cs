using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Background : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPosition;

    private void Start()
    {
        cameraPosition = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        // This version of Parallax simply follows the Player1 object as it is moved
        this.transform.position = new Vector3(cameraPosition.position.x, cameraPosition.position.y, 100f);
    }
}
