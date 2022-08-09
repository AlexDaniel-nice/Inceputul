using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour
{
    [Header("Camera Settings")]

    [SerializeField] Transform Camera;
    [SerializeField] float smoothing = 0.5f;
    [SerializeField] Vector3 off_pos;
    [SerializeField] Quaternion off_rot;

    private void FixedUpdate()
    {
        Vector3 desiredPoz = transform.position + off_pos;
        Vector3 smoothedPoz = Vector3.Lerp(Camera.transform.position, desiredPoz, smoothing);

        Camera.transform.position = smoothedPoz;
        Camera.LookAt(this.transform);
     // Camera.transform.rotation = off_rot;
    }

}
