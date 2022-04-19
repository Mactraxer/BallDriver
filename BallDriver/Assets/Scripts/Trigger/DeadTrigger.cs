using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DeadTrigger : MonoBehaviour
{

    public Action<IDeadable> OnDetectObject;

    private void OnTriggerExit(Collider other)
    {

        IDeadable component;

        if (other.TryGetComponent(out component))
        {
            OnDetectObject?.Invoke(component);
        }

    }

}
