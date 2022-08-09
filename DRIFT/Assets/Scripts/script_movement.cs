using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class script_movement : MonoBehaviour
{
    [Header("Car Settings")]

    [SerializeField] private float power = 1500f;
    [SerializeField] private wheel[] wheels;


    PlayerInputActions playerInputActions;
    Rigidbody car_rb;

    private void Awake()
    {
        car_rb = GetComponent<Rigidbody>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.movement.performed += ProcessInput;
    }

    float HrzMove;
    float VerMove;

    private void ProcessInput(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        HrzMove = direction.x;
        VerMove = direction.y;
    }
    private void ProcessForces()
    {
        foreach (wheel w in wheels)
        {
            w.Steer(HrzMove);
            w.Accelerate(VerMove * power);
            w.UpdatePos();
        }
    }

    private void FixedUpdate()
    {
        ProcessForces();
    }    
}
