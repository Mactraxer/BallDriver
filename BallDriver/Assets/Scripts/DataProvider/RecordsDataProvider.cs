using System.Collections.Generic;

public class RecordsDataProvider
{
    private PlayerPrefsStorage _storage;
    
    public void SetupDataProvider(PlayerPrefsStorage storage)
    {
        _storage = storage;
    }

    public void SaveRecord(RecordDataModel model)
    {
        _storage.PersistRecord(model);
    }

    public List<RecordDataModel> GetRecords()
    {
        return _storage.ReadAllRecords();
    }

}
