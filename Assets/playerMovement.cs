using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public CharacterController2D controller;

    public Animator MyAnim;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update() {

        MyAnim = GetComponent<Animator>();

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (horizontalMove != 0)
        {
            //MyAnim.Play("Horse-walk");
        }
        //else MyAnim.Play("Horse-idle");


        //MyAnim.Play("Horse walk");
        //else MyAnim.Play("Horse-idle");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }


}
