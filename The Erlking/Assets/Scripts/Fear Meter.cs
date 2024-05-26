using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearManager : MonoBehaviour
{

    public UIManager UI;

    public Flashlight flashlight; // Reference to the Flashlight script

    bool IsPlayerThroughPortal = true;

    // Fear variables
    private int fearLevel = 0;
    private int lastFearLevel;
    private float fearTimer = -1f;
    [SerializeField] private int maxFear = 300;

    // Sanity variables
    private float sanityTimer = -1f;

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerThroughPortal)
        {
            // When the flashlight is turned off
            if (flashlight.GetCurrentFlashlightStatus() == false)
            {
                Debug.Log("Starting fear timer!");
                fearTimer = fearLevel;
                UI.UpdateFear(fearLevel);


                while (flashlight.GetCurrentFlashlightStatus() == false)
                {
                    fearLevel = Mathf.RoundToInt(fearTimer);
                    lastFearLevel = fearLevel;

                    if (fearLevel >= maxFear)
                    {
                        // Trigger enemy spawn or game over
                        Debug.Log("Fear level reached critical point. Triggering enemy spawn or game over...");
                        break; // Exit the loop
                    }
                }
            }
            // When the flashlight is turned on
            else
            {
                fearTimer = -1f;
                sanityTimer = 0;

                Debug.Log("Decreasing fear!");

                while (flashlight.GetCurrentFlashlightStatus() == true)
                {
                    fearLevel = lastFearLevel - Mathf.RoundToInt(Time.deltaTime);
                    UI.UpdateFear(fearLevel);
                }

            }
        }
    }

    public int getMaxFear()
    {
        return maxFear;
    }

    public int getCurrentFear()
    {
        return fearLevel;
    }
}
