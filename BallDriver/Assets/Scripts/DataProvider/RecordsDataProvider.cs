using System.Collections.Generic;

public class RecordsDataProvider
{
    private IStorage _storage;

    private JSONSerializer _jsonSerializer;
    private const string RECORDS_COUNT_KEY = "Records";
    private int _recordsCount;

    public RecordsDataProvider(IStorage storage)
    {
        _storage = storage;
        _jsonSerializer = new JSONSerializer();
        _recordsCount = _storage.ReadIntValue(RECORDS_COUNT_KEY);

        if (_recordsCount == 0)
        {
            _storage.PersistIntValue(0, RECORDS_COUNT_KEY);
        }
    }

    public void SaveRecord(RecordDataModel model)
    {
        string json = _jsonSerializer.ConvertToJSON(model);
        _storage.PersistStringValue(json, $"{_recordsCount}");

        _recordsCount++;
        _storage.PersistIntValue(_recordsCount, RECORDS_COUNT_KEY);
    }

    public List<RecordDataModel> GetRecords()
    {
        List<RecordDataModel> _models = new List<RecordDataModel>();

        for (int i = 0; i < _recordsCount; i++)
        {
            var json = _storage.ReadStringValue($"{i}");
            RecordDataModel model = _jsonSerializer.ConvertFromJSON<RecordDataModel>(json);
            _models.Add(model);
        }

        return _models;
    }

}
