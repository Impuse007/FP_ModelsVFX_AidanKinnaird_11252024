using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Click : MonoBehaviour
{
    public Button button;          // Reference to the button
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip soundClip;     // The sound clip to play

    void Start()
    {
        // Add a listener to play the sound when the button is clicked
        button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        if (audioSource != null && soundClip != null)
        {
            // Play the assigned sound clip
            audioSource.PlayOneShot(soundClip);
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is not assigned.");
        }
    }
}