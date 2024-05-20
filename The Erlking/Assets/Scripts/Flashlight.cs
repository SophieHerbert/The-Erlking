using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private int maxBatteries = 3;
    [SerializeField] private float batteryTime = 10;

    private int currentBatteries = 0;
    private float timer = -1f;
    private Light spotlight;

    private void Awake()
    {
        TryGetComponent(out spotlight);
    }

    private void Start()
    {
        timer = 0;
        ToggleFlashlight(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) == true)
        {
            ToggleFlashlight(!spotlight.enabled);
        }

        if(spotlight.enabled == true)
        {
            timer += Time.deltaTime;
            if(timer>= batteryTime)
            {
                currentBatteries--;
                if (currentBatteries < 0)
                {
                    currentBatteries = 0;
                    timer = -1;
                    ToggleFlashlight(false); //instead trigger the flicker animation //ping pong mathf.ping pong for flicker
                }
                else
                {
                    timer = 0;
                }
            }
        }
    }
    public void ToggleFlashlight(bool toggle)
    {
        if(spotlight != null)
        {
            if(toggle == false ||toggle == true && (currentBatteries >0 || timer >= 0))
            {
                spotlight.enabled = toggle;
            }
            //toggle on IF charge remaining
                //charge remains if batteries > 0 timer>=0
        }
    }
}
