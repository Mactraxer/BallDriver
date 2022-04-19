
public interface IStorage
{

    public void PersistIntValue(int value, string key);
    public void PersistStringValue(string value, string key);


    public int ReadIntValue(string key);
    public string ReadStringValue(string key);

}
