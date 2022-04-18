using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnterTrigger : MonoBehaviour
{

    public Action<GameObject> OnDetectObject;

    private void OnTriggerEnter(Collider other)
    {
        OnDetectObject?.Invoke(other.gameObject);
    }

}
