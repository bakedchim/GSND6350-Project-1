using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    CanvasGroup canvasGroup;
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    // Update is called once per frame
    void Update()
    {
        // Set the minimap to be visible when the player holds the Tab key
        if (Input.GetKey(KeyCode.Tab))
        {
            canvasGroup.alpha = 1;
        }
        else
        {
            canvasGroup.alpha = 0;
        }
    }
}
