using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    CharacterController contrl;

    [SerializeField] float mouseSensivity;
    Camera cam;
    float xRotation;
    Vector3 velocity;

    private void Start()
    {
        contrl = GetComponent<CharacterController>();
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        Vector3 move = transform.right * x + transform.forward * z;

        contrl.Move(move * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 17;
        }
        else
        {
            movementSpeed = 10;
        }
    }
}
