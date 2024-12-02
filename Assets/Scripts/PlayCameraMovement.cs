using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCameraMovement : MonoBehaviour
{
    public Button playButton;         // Reference to the Play button
    public Button backButton;         // Reference to the Back button
    public Camera camera;             // Reference to the Camera
    public Transform playPosition;    // Target position and rotation for play
    public float moveDuration = 1.0f; // Duration for the movement (in seconds)

    private Vector3 previousPosition; // To store the camera's previous position
    private Quaternion previousRotation; // To store the camera's previous rotation

    void Start()
    {
        // Assign methods to the button click events
        playButton.onClick.AddListener(MoveCameraToPlay);
        backButton.onClick.AddListener(MoveCameraBack);
    }

    // Move the camera to the Play position
    private void MoveCameraToPlay()
    {
        // Save the current camera position and rotation
        previousPosition = camera.transform.position;
        previousRotation = camera.transform.rotation;

        // Start the coroutine to move and rotate the camera to the play position
        StartCoroutine(MoveCamera(camera.transform.position, playPosition.position, camera.transform.rotation, playPosition.rotation));
    }

    // Move the camera back to its previous position
    private void MoveCameraBack()
    {
        // Start the coroutine to move and rotate the camera back to the previous position
        StartCoroutine(MoveCamera(camera.transform.position, previousPosition, camera.transform.rotation, previousRotation));
    }

    // Coroutine to smoothly move and rotate the camera
    private IEnumerator MoveCamera(Vector3 startPos, Vector3 endPos, Quaternion startRot, Quaternion endRot)
    {
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            // Interpolate position and rotation
            camera.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / moveDuration);
            camera.transform.rotation = Quaternion.Lerp(startRot, endRot, elapsedTime / moveDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the camera reaches the exact target position and rotation
        camera.transform.position = endPos;
        camera.transform.rotation = endRot;
    }
}