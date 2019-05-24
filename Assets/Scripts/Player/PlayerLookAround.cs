using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour
{
    public new CameraController cameraController;
    public Transform lookUpCameraPosition;

    private PhysicalObject physicalObject;

    private bool hasTimerStarted = false;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<PhysicalObject>())
        physicalObject = gameObject.GetComponent<PhysicalObject>();   
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfHoldingUpKey();
    }

    private void CheckIfHoldingUpKey()
    {
        float verticalInput = 0f;
        float holdDur = 1.2f;

        verticalInput = Input.GetAxisRaw("Vertical");
        if (verticalInput > 0)
        {
            if (!hasTimerStarted)
            {
                timer = Time.time;
                hasTimerStarted = !hasTimerStarted;
                physicalObject.GetComponent<PlayerState>().IsLookingUp = true;
            }
            else
            {
                if (Time.time - timer > holdDur)
                {
                    timer = float.PositiveInfinity;
                    MoveCameraUp();
                }
            }
        }
        if (verticalInput == 0 && hasTimerStarted)
        {
            hasTimerStarted = !hasTimerStarted;
            timer = float.PositiveInfinity;
            cameraController.target = physicalObject.GetComponent<PhysicalObject>().body.transform;
            physicalObject.GetComponent<PlayerState>().IsLookingUp = false;
        }
    }


    private void MoveCameraUp()
    {
        cameraController.target = lookUpCameraPosition;
    }
}

