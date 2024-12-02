using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAnimTrigger : MonoBehaviour
{
    public Button yourButton;
    public Animator cameraAnimator;


    // Start is called before the first frame update
    void Start()
    {
        yourButton.onClick.AddListener(TriggerCameraAnimation);
    }

    void TriggerCameraAnimation()
    {
        cameraAnimator.SetTrigger("PlayCameraMovement");
    }

}
