using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //config
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float jumpSpeed = 5;
    [SerializeField] float climbSpeed = 3;
    [SerializeField] Vector2 deathKick = new Vector2(0, 25);

    //state
    bool isAlive = true;
    bool canJump = true;

    //cache references
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    Collider2D myCollider;
    Collider2D myFeetCollider; //collider for the player's feet
    float startingGravityScale;

    void Start()
    {
        //initiate cached references
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        startingGravityScale = myRigidbody.gravityScale;
    }

    void Update()
    {
        //call all player methods
        if (!isAlive) { return;}
        Jump();
        Run();
        ClimbLadder();
        FlipSprite();
        ExecuteDeath();

    }
    
    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //value is between -1 and 1
        Vector2 playerVelocity = new Vector2(controlThrow * moveSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }

    private void Jump()
    {
        canJump = myFeetCollider.IsTouchingLayers(LayerMask.GetMask("ground"));
        if (CrossPlatformInputManager.GetButtonDown("Jump") && canJump)
        {
            Vector2 playerVelocity = new Vector2(myRigidbody.velocity.x, jumpSpeed);
            myRigidbody.velocity = playerVelocity;

        }
    }

    private void ClimbLadder()
    {
        bool isOnStairs = myCollider.IsTouchingLayers(LayerMask.GetMask("ladders"));

        if (isOnStairs)
        {
            myAnimator.SetBool("isClimbing", true);
            float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
            Vector2 playerVelocity = new Vector2(myRigidbody.velocity.x, controlThrow * climbSpeed);
            myRigidbody.velocity = playerVelocity;
            myRigidbody.gravityScale = 0;
        }
        else
        {
            myAnimator.SetBool("isClimbing", false);
            myRigidbody.gravityScale = startingGravityScale;
        }
        /*
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > 0; //is true when player is moving vertically
        if (playerHasVerticalSpeed)
        {
            myAnimator.SetBool("isClimbing", true);
        }
        else
        {
            myAnimator.SetBool("isClimbing", false);
        }
        */
    }
    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > 0; //is true when player is moving horizontally
        if (playerHasHorizontalSpeed)
        {
            myAnimator.SetBool("isRunning", true);
            transform.localScale = new Vector3(Mathf.Sign(myRigidbody.velocity.x), 1f, 1f);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }

    private void ExecuteDeath()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("enemy","hazards")))
        {
            myAnimator.SetTrigger("isDying");
            myRigidbody.velocity = deathKick;
            isAlive = false;
        }
    }
}
