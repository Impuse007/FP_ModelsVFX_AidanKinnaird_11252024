using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAnimTrigger : MonoBehaviour
{
    public Button yourButton;      // Reference to the button
    public Animator cameraAnimator;  // Reference to the camera's Animator

    void Start()
    {
        // Disable the Animator to prevent it from playing immediately
        cameraAnimator.enabled = false;

        // Add listener for button click
        yourButton.onClick.AddListener(TriggerCameraAnimation);
    }

    void TriggerCameraAnimation()
    {
        // Enable the Animator just before triggering the animation
        cameraAnimator.enabled = true;

        // Set the trigger to start the animation
        cameraAnimator.SetTrigger("PlayCameraMovement");
    }
}
