using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 cameraOffset;
    public void ChangeCamerPosition(Vector2 center)
    {   
        transform.position=cameraOffset+(Vector3)center;
    }
}
