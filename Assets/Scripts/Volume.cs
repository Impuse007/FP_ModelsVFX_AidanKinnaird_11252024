using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider volumeSlider;      // Reference to the UI Slider
    public AudioSource audioSource; // Reference to the AudioSource

    void Start()
    {
        // Ensure the slider starts with the AudioSource's current volume
        if (volumeSlider != null && audioSource != null)
        {
            volumeSlider.value = audioSource.volume;

            // Add listener to handle value changes
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
        else
        {
            Debug.LogWarning("Slider or AudioSource is not assigned.");
        }
    }

    // Set the AudioSource volume based on the slider value
    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
}
