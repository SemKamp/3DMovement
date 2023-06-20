using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerCharacterController : MonoBehaviour
{
    private Vector3 jump;
    [SerializeField] float speed = 20.0f;
    [SerializeField] float rotateSpeed = 5;
    public Rigidbody rb;
    Vector3 moveDirection;
    public Transform playerTransform;
    float verticalInput;
    float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        jump = new Vector3(0.0f, 5.0f, 0.0f);
        verticalInput = Input.GetAxisRaw("vertical");
        horizontalInput = Input.GetAxisRaw("horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerTransform.forward * verticalInput + playerTransform.right * horizontalInput;

        // on ground
            rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
        //if (Input.GetKey(KeyCode.W) && Input.GetKey("left shift"))
        //{
        //    speed = 10f;
        //    transform.position += Vector3.forward * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    speed = 5f;
        //    transform.position += Vector3.forward * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position += Vector3.back * speed * Time.deltaTime;
        //}
        //if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y < 0.1)
        //{
        //    rb.AddForce(jump * 2, ForceMode.Impulse);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        //}
    }
}
