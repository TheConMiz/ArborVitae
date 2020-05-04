using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;

    public bool isAlive;

    private void Awake()
    {
        // Ensure that the current instance of PlayerManager is not destroyed upon reloading a scene.
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(instance);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        isAlive = true;
    }
}
