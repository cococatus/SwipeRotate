using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SwipeOrbit : MonoBehaviour
{
    void Update()
    {
        if (Input.touchSupported && Application.platform != RuntimePlatform.WebGLPlayer)
        {
            HandleTouch();
        }
        else
        {
            HandleMouse();
        }
    }

    private Vector3 startPos, endPos;
    private Vector3 angles;
    private float targetY;
    private float interpolatedY;
    private void HandleMouse()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            angles = transform.localRotation.eulerAngles;
            targetY = angles.y + (startPos - endPos).x;
            interpolatedY = angles.y;
        }
        
        interpolatedY = Mathf.Lerp(interpolatedY, targetY, Time.deltaTime*2);
        transform.eulerAngles = new Vector3(0, interpolatedY, 0);
    }

    private void HandleTouch()
    {
        if(Input.touchCount == 0)
            return;
        
        Touch touch = Input.GetTouch(0);

        // Handle finger movements based on TouchPhase
        switch (touch.phase)
        {
            //When a touch has first been detected, change the message and record the starting position
            case TouchPhase.Began:
                // Record initial touch position.
                startPos = touch.position;
                break;

            case TouchPhase.Ended:
                // Report that the touch has ended when it ends
                endPos = touch.position - (Vector2)startPos;
                angles = transform.localRotation.eulerAngles;
                targetY = angles.y + (startPos - endPos).x;
                interpolatedY = angles.y;
                break;
        }
        
        interpolatedY = Mathf.Lerp(interpolatedY, targetY, Time.deltaTime*2);
        transform.eulerAngles = new Vector3(0, interpolatedY, 0);
    }
}
