using UnityEngine;

public class Timer
{

    private float _startTime;

    public void Record()
    {
        _startTime = Time.fixedTime;
    }   
    
    public float Stop()
    {
        return Time.fixedTime - _startTime;
    }

}
