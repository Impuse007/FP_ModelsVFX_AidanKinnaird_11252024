using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox_Script : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed at which the skybox rotates

    private void Update()
    {
        // Rotate the skybox around the Y-axis
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}