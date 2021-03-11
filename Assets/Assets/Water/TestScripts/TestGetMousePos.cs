using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGetMousePos : MonoBehaviour
{
    public Camera ScenCam;
    public Vector3 mousePos;
    public Vector3 mousePointWorld;

    void Update()
    {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        // mousePointWorld = ScenCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScenCam.nearClipPlane));
        mousePointWorld = ScenCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScenCam.farClipPlane));
    }
}
