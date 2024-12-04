using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren_Light : MonoBehaviour
{
    public Light redLight; // Reference to the red light
    public Light blueLight; // Reference to the blue light
    public float flashInterval = 1.0f; // Time interval for each color (in seconds)
    private float timer = 0f; // Timer to track the flashing intervals
    private bool isRedActive = true; // Flag to track which light is currently active

    private void Start()
    {
        if (redLight == null || blueLight == null)
        {
            Debug.LogError("Both red and blue lights must be assigned.");
            return;
        }

        // Start with the red light active
        redLight.enabled = true;
        blueLight.enabled = false;
    }

    private void Update()
    {
        if (redLight == null || blueLight == null) return;

        timer += Time.deltaTime; // Increase the timer by the time passed

        if (timer >= flashInterval)
        {
            // Toggle between red and blue light
            isRedActive = !isRedActive;

            if (isRedActive)
            {
                // Activate the red light and deactivate the blue light
                redLight.enabled = true;
                blueLight.enabled = false;
            }
            else
            {
                // Activate the blue light and deactivate the red light
                redLight.enabled = false;
                blueLight.enabled = true;
            }

            // Reset the timer to start the next interval
            timer = 0f;
        }
    }
}