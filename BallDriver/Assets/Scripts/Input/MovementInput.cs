using System;
using UnityEngine;

public class MovementInput : MonoBehaviour
{

    private const string VERTICAL_AXIS_NAME = "Vertical";
    private const string HORIZONTAL_AXIS_NAME = "Horizontal";

    public Action<float> VerticalInputAction;
    public Action<float> HorizontalInputAction;
    
    void FixedUpdate()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        HandleHorizontalInput();
        HandleVerticalInput();
    }

    private void HandleVerticalInput()
    {
        var vecticalInput = Input.GetAxis(VERTICAL_AXIS_NAME);
        VerticalInputAction?.Invoke(vecticalInput);
    }

    private void HandleHorizontalInput()
    {
        var horizontalInput = Input.GetAxis(HORIZONTAL_AXIS_NAME);
        HorizontalInputAction?.Invoke(horizontalInput);
    }

}
