using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyInteraction : MonoBehaviour
{
    public MazeGameController mazeGameController;
    private GameObject keyObject;
    private GameObject keyMinimapIndicator;
    public Sprite collectedKeySprite;
    public Material keyMaterial;
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Find the key object in children
        keyObject = transform.Find("KeyObject").gameObject;
        // Find the key minimap indicator in children
        keyMinimapIndicator = transform.Find("KeyMinimapIndicator").gameObject;
        // Set the key material to the key object
        keyObject.GetComponent<Renderer>().material = keyMaterial;
    }

    // Check for trigger collision of the key object
    void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with the key
        if (other.gameObject.CompareTag("Player"))
        {
            // Set the key object to inactive
            keyObject.SetActive(false);
            // Set the collected key sprite to the key minimap indicator
            keyMinimapIndicator.GetComponent<SpriteRenderer>().sprite = collectedKeySprite;
            // Collect the key based on tag
            mazeGameController.CollectKey(transform.tag);
        }
    }
}
