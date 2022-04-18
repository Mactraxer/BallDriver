using System;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public Action<GameObject> OnDetectObject;

    private void OnTriggerEnter(Collider other)
    {
        OnDetectObject?.Invoke(other.gameObject);
    }
}
