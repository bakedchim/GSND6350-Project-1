using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    // PlayerCamera child component
    public GameObject camTarget;
    private float pLerp = 0.5f;
    private float rLerp = 0.5f;
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Get the component named CamTarget
        camTarget = GameObject.Find("CamTarget");
    }

    // Update is called once per frame
    void Update()
    {
        // Keep the camera position while ball is rolling
        transform.position = Vector3.Lerp(transform.position, camTarget.transform.position, pLerp);
        // Keep the camera rotation while ball is rolling
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.transform.rotation, rLerp);
    }
}
