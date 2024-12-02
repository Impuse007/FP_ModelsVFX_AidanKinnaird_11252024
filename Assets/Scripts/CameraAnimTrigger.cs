using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAnimTrigger : MonoBehaviour
{
    public Button optionsButton;     // Reference to the Options button
    public Button backButton;        // Reference to the Back button
    public Animator cameraAnimator;  // Reference to the camera's Animator

    void Start()
    {
        // Disable the Animator to prevent it from playing immediately
        cameraAnimator.enabled = false;

        // Add listeners for button clicks
        optionsButton.onClick.AddListener(PlayForwardAnimation);
        backButton.onClick.AddListener(PlayReverseAnimation);
    }



    void PlayForwardAnimation()
    {
        //cameraAnimator.ResetTrigger("CameraAnim");
        cameraAnimator.enabled = true;
        cameraAnimator.SetTrigger("CameraAnim");
    }

    void PlayReverseAnimation()
    {
        cameraAnimator.enabled = true;
        cameraAnimator.SetTrigger("CameraBack");
    }
}
