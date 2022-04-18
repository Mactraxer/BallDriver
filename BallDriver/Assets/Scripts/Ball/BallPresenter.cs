using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(BallMover))]
public class BallPresenter : MonoBehaviour
{
    
    private PlayerInput _input;
    private BallMover _mover;

    private void OnEnable()
    {
        _input.VerticalInputAction += VerticalInput;
        _input.HorizontalInputAction += HorizontalInput;
    }

    private void OnDisable()
    {
        _input.VerticalInputAction -= VerticalInput;
        _input.HorizontalInputAction -= HorizontalInput;
    }

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _mover = GetComponent<BallMover>();
    }

    private void VerticalInput(float value)
    {
        _mover.MoveStaight(value);
    }

    private void HorizontalInput(float value)
    {
        _mover.MoveSideways(value);
    }

}
