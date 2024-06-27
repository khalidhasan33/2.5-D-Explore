using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] Animator myAnimator;

    Vector3 moveInput;
    Rigidbody myRigidbody;

    bool isAlive = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(!isAlive) { return;}

        Run();
        // FlipSprite();
    }

    void OnMove(InputValue value)
    {
        if(!isAlive) { return;}

        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Run()
    {
        Vector3 playerVelocity = new Vector3 (moveInput.x * moveSpeed, myRigidbody.velocity.y, moveInput.y * moveSpeed);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isWalking", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector3 (Mathf.Sign(myRigidbody.velocity.x), 1f);      
        }
    }
}
