using System;
using UnityEngine;

[Serializable]
public struct RecordDataModel
{
    [SerializeField]
    private string _recordHolderName;
    [SerializeField]
    private float _time;

    public RecordDataModel(string recordHolderName, float time)
    {
        _recordHolderName = recordHolderName;
        _time = time;
    }

    public string RecordHolderName => _recordHolderName;
    public float Time => _time;

}
