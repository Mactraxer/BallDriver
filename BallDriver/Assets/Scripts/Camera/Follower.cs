using UnityEngine;

public class Follower : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offetVector;

    private void FixedUpdate()
    {
        if (_target == null) return;

        transform.position = _target.position + _offetVector;
    }

}
