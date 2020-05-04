using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for managing checkpoints.
public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    public Vector2 lastCheckpoint;

    private void Awake()
    {
        // Ensure that the current instance of LevelManager is not destroyed upon reloading a scene.
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
}
