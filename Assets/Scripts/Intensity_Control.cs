using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intensity_Control : MonoBehaviour
{
    public Material targetMaterial; // The material whose emission intensity will be changed
    public float emissionSpeed = 1f; // Speed at which emission intensity changes
    public float minEmissionIntensity = 0f; // Minimum emission intensity (off)
    public float maxEmissionIntensity = 1f; // Maximum emission intensity (fully glowing)

    private float currentEmissionIntensity; // Current emission intensity
    private bool increasing = true; // Flag to track whether the intensity is increasing or decreasing

    private void Start()
    {
        if (targetMaterial == null)
        {
            Debug.LogError("Target material not assigned.");
            return;
        }

        // Get the initial emission intensity from the material
        currentEmissionIntensity = minEmissionIntensity;
        UpdateEmissionIntensity();
    }

    private void Update()
    {
        // Update the emission intensity based on the current state
        if (increasing)
        {
            currentEmissionIntensity += emissionSpeed * Time.deltaTime;
            if (currentEmissionIntensity >= maxEmissionIntensity)
            {
                currentEmissionIntensity = maxEmissionIntensity;
                increasing = false; // Start decreasing the intensity
            }
        }
        else
        {
            currentEmissionIntensity -= emissionSpeed * Time.deltaTime;
            if (currentEmissionIntensity <= minEmissionIntensity)
            {
                currentEmissionIntensity = minEmissionIntensity;
                increasing = true; // Start increasing the intensity
            }
        }

        // Update the emission intensity on the material
        UpdateEmissionIntensity();
    }

    private void UpdateEmissionIntensity()
    {
        // Set the emission intensity based on the current intensity
        Color emissionColor = targetMaterial.GetColor("_EmissionColor");
        emissionColor *= currentEmissionIntensity;
        targetMaterial.SetColor("_EmissionColor", emissionColor);

        // Ensure the material is updated by forcing the material to re-render with the new values
        DynamicGI.SetEmissive(targetMaterial, emissionColor);
    }
}