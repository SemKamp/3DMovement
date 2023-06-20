using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public Camera playerCamera;

    float speed = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    float rotationX = 0;
    //charactercontroller die je gebruikt
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //cursor kan scherm niet uit
        Cursor.lockState = CursorLockMode.Locked;
        //cursor kun je niet zien
        Cursor.visible = false;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

    }
}
