using System;

[Serializable]
public struct RecordDataModel
{
    private string _recordHolderName;
    private float _time;

    public RecordDataModel(string recordHolderName, float time)
    {
        _recordHolderName = recordHolderName;
        _time = time;
    }

    public string RecordHolderName => _recordHolderName;
    public float Time => _time;

}
