using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsStorage
{

    private JSONSerializer _jsonSerializer;
    private const string RECORDS_COUNT_KEY = "Records";
    private int _recordsCount;

    public void SetupStorage()
    {
        _jsonSerializer = new JSONSerializer();
        _recordsCount = PlayerPrefs.GetInt(RECORDS_COUNT_KEY, 0);
        

        if (_recordsCount == 0)
        {
            PlayerPrefs.SetInt(RECORDS_COUNT_KEY, 0);
        }

    }

    public void PersistRecord(RecordDataModel model)
    {
        string json = _jsonSerializer.ConvertToJSON(model);
        PlayerPrefs.SetString($"{_recordsCount}", json);
        
        _recordsCount++;
        PlayerPrefs.SetInt(RECORDS_COUNT_KEY, _recordsCount);
        PlayerPrefs.Save();
    }

    public List<RecordDataModel> ReadAllRecords()
    {
        List<RecordDataModel> _models = new List<RecordDataModel>();

        for (int i = 0; i < _recordsCount; i++)
        {
            var json = PlayerPrefs.GetString($"{i}");
            RecordDataModel model = _jsonSerializer.ConvertFromJSON<RecordDataModel>(json);
            _models.Add(model);
        }

        return _models;
    }

}
