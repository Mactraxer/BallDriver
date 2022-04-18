using UnityEngine;

public class BallMover : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _forceValue;
    private float _slowerRate = 2f;

    public void MoveStaight(float direction)
    {
        if (_rigidbody.position.y > 1) return;

        Vector3 forceVector = new Vector3(0, 0, direction * _forceValue);
        _rigidbody.AddForce(forceVector, ForceMode.Acceleration);
    }

    public void MoveSideways(float direction)
    {
        if (_rigidbody.position.y > 1) return;

        Vector3 forceVector = new Vector3(direction * _forceValue / _slowerRate, 0, 0);
        _rigidbody.AddForce(forceVector, ForceMode.Acceleration);
    }

}
