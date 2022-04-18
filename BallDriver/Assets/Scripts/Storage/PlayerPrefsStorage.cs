using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsStorage
{

    private JSONSerializer _jsonSerializer;
    private const string RECORDS_COUNT_KEY = "Records";
    private int _recordsCount;
    private int _currentRecord;


    public void SetupStorage()
    {
        _jsonSerializer = new JSONSerializer();
        _recordsCount = PlayerPrefs.GetInt(RECORDS_COUNT_KEY, 0);
        _currentRecord = 0;

        if (_recordsCount == 0)
        {
            PlayerPrefs.SetInt(RECORDS_COUNT_KEY, 0);
        }
    }

    public void PersistRecord(RecordDataModel model)
    {
        string json = _jsonSerializer.ConvertToJSON(model);
        PlayerPrefs.SetString($"{_currentRecord}", json);
        _recordsCount++;
        _currentRecord++;
    }

    public List<RecordDataModel> ReadAllRecords()
    {
        List<RecordDataModel> _models = new List<RecordDataModel>();

        for (int i = 0; i < _recordsCount; i++)
        {
            RecordDataModel model = _jsonSerializer.ConvertFromJSON<RecordDataModel>(PlayerPrefs.GetString($"{i}"));
            _models.Add(model);
        }

        return _models;
    }

}
