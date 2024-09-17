using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraRotation : MonoBehaviour
{
    private Vector2 turn;
    private float sensitivity = 2f;

    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
