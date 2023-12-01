using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLikeMovement : MonoBehaviour
{
    private readonly float moveSpeed = 400.0f;
    private readonly float rotateSpeed = 300.0f;

    private void Update()
    {
        // Check if the right mouse button is being pressed
        if (Input.GetMouseButton(1))
        {
            // Rotate the camera based on mouse movement
            float yaw = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
            float pitch = -Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
            transform.eulerAngles += new Vector3(pitch, yaw, 0);
        }

        // Move the camera using WASD keys
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float ascend = 0;

        if (Input.GetKey(KeyCode.E))
            ascend = moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
            ascend = -moveSpeed * Time.deltaTime;

        Vector3 move = new Vector3(horizontal, ascend, vertical);
        transform.Translate(move, Space.Self);
    }
}
