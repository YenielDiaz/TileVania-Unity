using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    bool isFacingRight;

    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0);
        ChangeDirection();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("something happened");
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        
    }

    private void ChangeDirection()
    {
        if (Mathf.Sign(transform.localScale.x) > 0) isFacingRight = true;
        else isFacingRight = false;

        if(isFacingRight)
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y);
        else
            myRigidbody.velocity = new Vector2(-myRigidbody.velocity.x, myRigidbody.velocity.y);
    }

}
