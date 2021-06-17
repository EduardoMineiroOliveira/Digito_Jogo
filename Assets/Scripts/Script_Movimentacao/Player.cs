﻿using UnityEngine;

public class Player : MonoBehaviour {

    CharacterController controller;

    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    public float forwardSpeed = 9f;
    public float strafeSpeed = 10f;
    public float jumpSpeed;



    float gravity;
   
    float maxJumpHeight = 4f;
    float timeToMaxHeight = 0.5f;


    public Animator anim; //variavel de animação


    void Start() {

        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;

    }

    void Update() {

        



        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");


        

        // force = input * speed * direction
        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        vertical += gravity * Time.deltaTime * Vector3.up;


        if (controller.isGrounded) {
            vertical = Vector3.down;
        }

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) {
            vertical = jumpSpeed * Vector3.up;
        }

        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0) {
            vertical = Vector3.zero;
        }






        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);

    }

}
