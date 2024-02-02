using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public float panSpeed;
    public float zoomSpeed;
    private Vector2[] lastTouchPositions = new Vector2[2];

    void Update()
    {
        HandlePanInput();
        HandlePinchZoomInput();
    }

    void HandlePanInput()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            Vector3 moveVector = new Vector3(-touchDeltaPosition.x, 0, -touchDeltaPosition.y) * panSpeed * Time.deltaTime;
            transform.Translate(moveVector, Space.World);
        }
    }

    void HandlePinchZoomInput()
    {
        if (Input.touchCount == 2)
        {
            Vector2[] newTouchPositions = { Input.GetTouch(0).position, Input.GetTouch(1).position };
            if (Input.GetTouch(1).phase == TouchPhase.Began)
            {
                lastTouchPositions = newTouchPositions;
            }

            float oldDistance = Vector2.Distance(lastTouchPositions[0], lastTouchPositions[1]);
            float newDistance = Vector2.Distance(newTouchPositions[0], newTouchPositions[1]);
            float deltaDistance = oldDistance - newDistance;

            ZoomCamera(deltaDistance * zoomSpeed);

            lastTouchPositions = newTouchPositions;
        }
    }

    void ZoomCamera(float deltaMagnitudeDiff)
    {
        Camera.main.fieldOfView += deltaMagnitudeDiff * 0.01f;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 10f, 80f); // Adjust min and max FOV as needed
    }
}
