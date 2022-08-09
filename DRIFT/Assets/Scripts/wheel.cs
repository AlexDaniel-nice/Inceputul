using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour
{
    [SerializeField] bool Powered = false;
    [SerializeField] float MaxSteerAngle;
    [SerializeField] float Offset;

    [SerializeField] Transform wMesh;

    private float turnAngle;
    private WheelCollider wCol;

    private void Start()
    {
        wCol = GetComponent<WheelCollider>();
    }

    public void Steer(float steerInput)
    {
        turnAngle = steerInput * MaxSteerAngle + Offset;
        wCol.steerAngle = turnAngle;
    }
    
    public void Accelerate(float powerInput)
    {
        if (Powered) wCol.motorTorque = powerInput;
        else wCol.brakeTorque = 0;
    }

    public void UpdatePos()
    {
        Vector3 pos;
        Quaternion rot;

        wCol.GetWorldPose(out pos, out rot);
        wMesh.transform.position = pos;
        wMesh.transform.rotation = rot;
    }

}
