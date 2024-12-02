using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovements : MonoBehaviour
{
    public Button optionsButton;     // Reference to the Options button
    public Button backButton;        // Reference to the Back button
    public Camera camera;            // Reference to the Camera
    public Transform optionsPosition; // Position to move the camera for options
    public Transform startPosition;   // Original starting position of the camera

    // Duration for the movement (in seconds)
    public float moveDuration = 1.0f;

    void Start()
    {
        // Add listeners for button clicks
        optionsButton.onClick.AddListener(MoveCameraToOptions);
        backButton.onClick.AddListener(MoveCameraBack);
    }

    // Move the camera to the options position
    void MoveCameraToOptions()
    {
        // Start the camera movement to the options position
        StartCoroutine(MoveCamera(camera.transform.position, optionsPosition.position));
    }

    // Move the camera back to its starting position
    void MoveCameraBack()
    {
        // Start the camera movement back to the starting position
        StartCoroutine(MoveCamera(camera.transform.position, startPosition.position));
    }

    // Coroutine to smoothly move the camera between two positions
    IEnumerator MoveCamera(Vector3 startPos, Vector3 endPos)
    {
        float elapsedTime = 0f;

        // While the movement is not complete
        while (elapsedTime < moveDuration)
        {
            // Calculate the new position based on time
            camera.transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / moveDuration));

            // Optionally, you can add a smooth rotation with Lerp
            // camera.transform.rotation = Quaternion.Lerp(startRotation, endRotation, (elapsedTime / moveDuration));

            // Increase the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the camera reaches the exact end position
        camera.transform.position = endPos;
    }
}