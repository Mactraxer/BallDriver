using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MovementInput))]
[RequireComponent(typeof(BallMover))]
public class BallPresenter : MonoBehaviour, IWinable, ILoseable
{

    [SerializeField] private Text _speedText;

    private MovementInput _input;
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

    private void OnDestroy()
    {
        _speedText.enabled = false;
    }

    private void Awake()
    {
        _input = GetComponent<MovementInput>();
        _mover = GetComponent<BallMover>();
    }

    private void FixedUpdate()
    {
        _speedText.text = string.Format("Speed = {0:f} m/s", _mover.CurrentSpeed);
    }

    private void VerticalInput(float value)
    {
        _mover.MoveStaight(value);
    }

    private void HorizontalInput(float value)
    {
        _mover.MoveSideways(value);
    }

    void IDestroyable.DestroySelf()
    {
        Destroy(gameObject);
    }

}
