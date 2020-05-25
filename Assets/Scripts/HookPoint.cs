using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPoint : MonoBehaviour
{
    private GameManager gameManager;

    private bool active;

    private void Start()
    {
        gameManager= GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        // Hook Points are only visible and active in the presence of a Spider.
        active = gameManager.GetHasSpider();
        this.gameObject.GetComponent<CircleCollider2D>().enabled = active;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = active;
    }
}
