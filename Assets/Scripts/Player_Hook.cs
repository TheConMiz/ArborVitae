using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hook : MonoBehaviour
{
    private DistanceJoint2D hook;

    private GameObject previousHookPoint;

    private LineRenderer hookWire;

    //private AudioManager audioManager;

    private GameManager gameManager;

    private void Start()
    {
        //audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        hook = this.gameObject.GetComponent<DistanceJoint2D>();

        hookWire = GameObject.FindGameObjectWithTag("HookWire").GetComponent<LineRenderer>();

        hook.enabled = false;

        hookWire.enabled = false;
    }

    private void Update()
    {
        if (!gameManager.GetHasSpider())
        {
            hook.enabled = false;
            hookWire.enabled = false;
        }
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                Vector2 target = Camera.main.ScreenToWorldPoint(touch.position);

                foreach (GameObject hookPoint in GameObject.FindGameObjectsWithTag("Hook"))
                {
                    if (Physics2D.OverlapPoint(target) == hookPoint.GetComponent<CircleCollider2D>())
                    {                        
                        if (touch.phase == TouchPhase.Ended)
                        {

                            if (hookPoint == previousHookPoint && hook.enabled)
                            {
                                hook.enabled = false;
                                hookWire.enabled = false;
                            }

                            else 
                            {
                                //audioManager.PlaySound("hookThrow");

                                hook.enabled = true;

                                hook.connectedBody = hookPoint.GetComponent<Rigidbody2D>();

                                hook.distance = 1.5f;

                                hookWire.enabled = true;

                                hookWire.SetPosition(0, this.gameObject.transform.position);

                                hookWire.SetPosition(1, hookPoint.transform.position);
                            }
                                
                            previousHookPoint = hookPoint;
                        }
                    }
                }
            }
        }
        hookWire.SetPosition(0, this.gameObject.transform.position);
    }


}
