using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //config
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float jumpSpeed = 5;

    //state
    bool isAlive = true;
    bool canJump = true;

    //cache references
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    Collider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        canJump = myCollider.IsTouchingLayers(LayerMask.GetMask("ground"));
        Jump();
        Run();
        FlipSprite();
    }
    
    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //value is between -1 and 1
        Vector2 playerVelocity = new Vector2(controlThrow * moveSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }

    private void Jump()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump") && canJump)
        {
            Vector2 playerVelocity = new Vector2(myRigidbody.velocity.x, jumpSpeed);
            myRigidbody.velocity = playerVelocity;
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > 0; //is true when player is moving
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
}
