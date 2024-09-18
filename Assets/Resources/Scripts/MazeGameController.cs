using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGameController : MonoBehaviour
{
    [SerializeField] private GameObject blueSphere;
    [SerializeField] private GameObject greenSphere;
    [SerializeField] private GameObject purpleSphere;
    private bool allKeysCollected = false;
    private GameObject keyMinimapIndicator;
    public Sprite collectedKeySprite;
    public Material winDoorMaterial;
    private GameObject doorObject;
    public GameObject winCanvas;

    private Dictionary<string, bool> keyObjects = new Dictionary<string, bool>{
        {"BlueKey", false},
        {"GreenKey", false},
        {"PurpleKey", false}
    };

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Find the key minimap indicator in children
        keyMinimapIndicator = transform.Find("KeyMinimapIndicator").gameObject;
        // Find the door object in children
        doorObject = transform.Find("DoorObject").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        // if all keys are collected
        if (keyObjects["BlueKey"] && keyObjects["GreenKey"] && keyObjects["PurpleKey"])
        {
            allKeysCollected = true;
            // Set the collected key sprite to the key minimap indicator
            keyMinimapIndicator.GetComponent<SpriteRenderer>().sprite = collectedKeySprite;
            // Set the win door material to the door object
            doorObject.GetComponent<Renderer>().material = winDoorMaterial;
        }
    }

    // Check for trigger collision
    void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with the blue sphere
        if (other.gameObject.CompareTag("Player"))
        {
            // If all keys are collected, win the game
            if (allKeysCollected)
            {
                WinGame();
            }
        }
    }

    public void CollectKey(string keyName)
    {
        keyObjects[keyName] = true;
        if (keyName == "BlueKey")
        {
            blueSphere.SetActive(false);
        }
        else if (keyName == "GreenKey")
        {
            greenSphere.SetActive(false);
        }
        else if (keyName == "PurpleKey")
        {
            purpleSphere.SetActive(false);
        }
    }

    private void WinGame()
    {
        // Stop time
        Time.timeScale = 0;
        // Show the win canvas
        winCanvas.SetActive(true);
    }

    public void RestartGame()
    {   
        // Reset time
        Time.timeScale = 1;
        // Reload the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name); 
    }
}
