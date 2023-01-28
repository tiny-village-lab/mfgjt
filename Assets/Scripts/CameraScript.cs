using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset;

    void LateUpdate()
    {
        transform.position = player.position + cameraOffset;
    }
}
