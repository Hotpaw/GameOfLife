using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    float minFov = 3f;
    float maxFov = 10f;
    float sensitivity = 10f;

    private void Update()
    {
        float ortographicSize = Camera.main.orthographicSize;
        ortographicSize += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        ortographicSize = Mathf.Clamp(ortographicSize, minFov, maxFov);
        Camera.main.orthographicSize = ortographicSize;
    }
   
}
