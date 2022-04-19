using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LoseTrigger : MonoBehaviour
{

    public Action<ILoseable> OnDetectObject;

    private void OnTriggerExit(Collider other)
    {

        ILoseable component;

        if (other.TryGetComponent(out component))
        {
            OnDetectObject?.Invoke(component);
        }

    }

}
