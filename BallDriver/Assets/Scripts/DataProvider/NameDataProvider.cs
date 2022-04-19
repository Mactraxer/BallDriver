

public class NameDataProvider 
{

    private IStorage _storage;

    private const string NAME_KEY = "Name";

    public NameDataProvider(IStorage storage)
    {
        _storage = storage;
    }

    public void SetName(string name)
    {
        _storage.PersistStringValue(name, NAME_KEY);
    }

    public string GetName()
    {
        return _storage.ReadStringValue(NAME_KEY);
    }

}
