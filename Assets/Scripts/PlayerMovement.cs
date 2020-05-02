using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Animator animator;

    public FloatingJoystick joystick;

    float horMove = 0f;

    public float runSpeed = 160f;

    bool jump = false;

    void Update()
    {
        horMove = joystick.Horizontal * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(joystick.Horizontal));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;

            animator.SetBool("Jump", jump);
        }
    }

    public void OnLanding()
    {
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
