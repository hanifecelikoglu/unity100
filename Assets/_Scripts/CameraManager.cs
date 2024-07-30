using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Transform")]
    public Transform target;

    [Space(10)]
    [Header("Camera Speed")]
    public float cameraSpeed;

    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y), cameraSpeed);
    }
}
