using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool movingForward = Input.GetKey("w");
        bool jumping = Input.GetKey("space");
        bool running = Input.GetKey("left shift");
        bool isWalking = animator.GetBool("IsWalking");
        bool isRunning = animator.GetBool("IsRunning");
        

        //als player niet aan het lopen is en op w drukt:
        if (!isWalking && movingForward)
        {
            // zet de bool IsWalking naar true
            animator.SetBool("IsWalking", true);
        }
        //als de player loopt en niet op w drukt:
        if (isWalking && !movingForward)
        {
            // zet de bool IsWalking naar false
            animator.SetBool("IsWalking", false);
        }
        if (!isRunning && (movingForward && running))
        {
            // zet de bool IsWalking naar false
            animator.SetBool("IsRunning", true);
        }
        if (isRunning && (!movingForward || !running))
        {
            // zet de bool IsWalking naar false
            animator.SetBool("IsRunning", false);
        }
        if (jumping && rb.velocity.y > 0.001)
        {
            Debug.Log("BUWHAA");
            animator.SetBool("IsJumping", true);
           // animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

    }



}
