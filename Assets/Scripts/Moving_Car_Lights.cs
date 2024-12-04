using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Car_Lights : MonoBehaviour
{
    public Light carLight; // The car's light (headlight)
    public float speed = 5f; // Speed of the light movement
    public float resetTime = 3f; // Time before the light resets and starts again
    public Vector3 startPosition; // Starting position of the light
    public Vector3 endPosition; // End position where the light will move to
    private float timer = 0f; // Timer to track when to reset the light's position

    private void Start()
    {
        if (carLight == null)
        {
            Debug.LogError("Car light is not assigned.");
            return;
        }

        // Initialize the starting position of the light
        carLight.transform.position = startPosition;
    }

    private void Update()
    {
        if (carLight == null) return;

        // Move the light towards the end position
        carLight.transform.position = Vector3.MoveTowards(carLight.transform.position, endPosition, speed * Time.deltaTime);

        // If the light has reached the end position, start the timer to reset it
        if (carLight.transform.position == endPosition)
        {
            timer += Time.deltaTime;

            // Once the timer exceeds the reset time, reset the light's position
            if (timer >= resetTime)
            {
                // Reset position and timer
                carLight.transform.position = startPosition;
                timer = 0f;
            }
        }
    }
}