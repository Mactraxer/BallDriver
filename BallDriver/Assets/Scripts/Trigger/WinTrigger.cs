using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WinTrigger : MonoBehaviour
{

    public Action<IWinable> OnDetectObject;

    private void OnTriggerEnter(Collider other)
    { 

        IWinable component;

        if (other.TryGetComponent(out component))
        {
            OnDetectObject?.Invoke(component);
        }

    }

}
