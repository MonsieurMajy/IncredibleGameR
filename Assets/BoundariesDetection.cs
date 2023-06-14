using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundariesDetection : MonoBehaviour
{
private void OnTriggerEnter(Collider other)
    {

            // Player is inside the circuit boundary
        
    }

    private void OnTriggerExit(Collider other)
    {
            // Player has exited the circuit boundary
            Debug.Log("Player has exited the circuit!");
            Time.timeScale = 0;
    }
}
