using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // PlayerCamera child component
    public GameObject playerCamera;

    // Rigidbody component
    private Rigidbody rb;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        // Get the component named PlayerCamera
        playerCamera = GameObject.Find("PlayerCamera");
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player using arrow keys
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(playerCamera.transform.forward * 10);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-playerCamera.transform.forward * 10);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-playerCamera.transform.right * 10);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(playerCamera.transform.right * 10);
        }
    }
}
