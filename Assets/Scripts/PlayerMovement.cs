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

    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player1").GetComponent<Animator>();
    }

    void Update()
    {
        horMove = joystick.Horizontal * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(joystick.Horizontal));

        vertMove = joystick.Vertical;

        // Code for Jump Settings: instruct the animator to play the correct animation, and coordinate with the CharacterController.
        if ((Input.GetButtonDown("Jump") || vertMove >= .5f) && Time.time > jumpCooldown)
        {
            jump = true;

            animator.SetBool("Jump", jump);

            jumpCooldown = Time.time + 1.5f;
        }
    }

    public void OnLanding()
    {
        // Checks whether the Player1 has landed after jumping to coordinate with the animator and the CharacterController.
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
