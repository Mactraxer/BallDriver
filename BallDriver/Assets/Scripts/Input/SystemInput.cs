using System;
using UnityEngine;

public class SystemInput : MonoBehaviour
{

    public Action OnInputPause;

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            OnInputPause?.Invoke();
        }
    }

}
