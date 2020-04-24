using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Animator animator;

    float horMove = 0f;

    public float runSpeed = 100f;

    bool jump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;

            animator.SetBool("Jump", true);
        }
    }

    public void OnLanding()
    {
         animator.SetBool("Jump", false);
    }

    void FixedUpdate()
    {

        controller.Move(horMove * Time.fixedDeltaTime, false, jump);

        jump = false;
    }
}
