using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private static GameObject player1;

    [SerializeField]
    private bool isAlive, hasSpider;

    [SerializeField]
    private Vector2 lastCheckpoint;

    private void Awake()
    {
        // Ensure that the current instance of GameManager is not destroyed upon reloading a scene.
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(instance);
        }

        else
        {
            Destroy(gameObject);
        }

        // Establish player Game Object
        player1 = GameObject.FindGameObjectWithTag("Player1");
    }

    private void Start()
    {
        isAlive = true;
        hasSpider = false;
    }

    public Vector2 GetLastCheckpoint()
    {
        return lastCheckpoint;
    }

    public void SetLastCheckpoint(Vector2 newCheckpoint)
    {
        lastCheckpoint = newCheckpoint;
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }

    public void SetIsAlive(bool newIsAlive)
    {
        isAlive = newIsAlive;
    }

    public Transform GetPlayerPosition()
    {
        return player1.transform;
    }

    public Rigidbody2D GetPlayerRigidBody()
    {
        return player1.GetComponent<Rigidbody2D>();
    }

    public Vector3 GetPlayerScale()
    {
        return player1.transform.localScale;
    }

    public bool GetHasSpider()
    {
        return hasSpider;
    }

    public void SetHasSpider(bool newHasSpider)
    {
        hasSpider = newHasSpider;
    }
}