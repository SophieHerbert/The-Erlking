using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public Flashlight flashlight; // Reference to the Flashlight script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player as the trigger
        {
            flashlight.SetCurrentBatteries(1); // Increase the battery count by 1
            Destroy(gameObject); // Destroy the battery object after use
        }
    }
}