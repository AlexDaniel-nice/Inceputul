using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class script_movement : MonoBehaviour
{
    #region Car parameters
    
    [Header("Car Settings")]

    [SerializeField] private float power = 1500f;
    [SerializeField] private wheel[] wheels;
    [SerializeField] Transform centerOfMass;
    #endregion

    Player_Input playerInputActions;
    Rigidbody car_rb;

    private void Awake()
    {
        car_rb = GetComponent<Rigidbody>();
        car_rb.centerOfMass = centerOfMass.localPosition;

        playerInputActions = new Player_Input();
        playerInputActions.Player.Enable();
    }

    float HrzMove;
    float VerMove;

    private void ProcessForces()
    {
        foreach (wheel w in wheels)
        {
            w.Steer(HrzMove);
            w.Accelerate(VerMove * power);
            w.UpdatePos();
        }
    }

    private void Update()
    {
        VerMove = playerInputActions.Player.Acceleration.ReadValue<float>();
        HrzMove = playerInputActions.Player.Steer.ReadValue<float>();
    }
    private void FixedUpdate()
    {
        ProcessForces();
    }    
}
