using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private Animator animator;
    public FloatingJoystick joystick;

    float horMove = 0f;
    float vertMove = 0f;

    public float runSpeed = 160f;
    private float jumpCooldown = 0f;

    bool jump = false;

    private Vector2 firstTouch, lastTouch;

    private float dragLength;

    void Start()
    {
        dragLength = Screen.height * 15 / 100;

        animator = GameObject.FindGameObjectWithTag("Player1").GetComponent<Animator>();
    }


    void Update()
    {
        horMove = joystick.Horizontal * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(joystick.Horizontal));

        vertMove = joystick.Vertical;

        // Jump Settings
        if ((Input.GetButtonDown("Jump") || vertMove >= .5f) && Time.time > jumpCooldown)
        {
            jump = true;

            animator.SetBool("Jump", jump);

            jumpCooldown = Time.time + 1.5f;
        }

        // Touch Controls for Jumping -- Not Working
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstTouch = touch.position;
                lastTouch = touch.position;
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                lastTouch = touch.position;
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                lastTouch = touch.position;

                if (Mathf.Abs(lastTouch.y - firstTouch.y) > dragLength)
                {
                    if (lastTouch.y > firstTouch.y)
                    {
                        Debug.Log("Jump");
                    }
                }
            }
        }
    }

    public void OnLanding()
    {
        Debug.Log("LANDED");
        jump = false;

        animator.SetBool("Jump", jump);
    }

    void FixedUpdate()
    {
        controller.Move(horMove * Time.fixedDeltaTime, false, jump);

        jump = false;

        animator.SetBool("Jump", jump);
    }
}
