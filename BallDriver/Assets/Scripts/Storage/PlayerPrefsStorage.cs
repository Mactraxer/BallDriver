using UnityEngine;

public class PlayerPrefsStorage : IStorage
{

    void IStorage.PersistIntValue(int value, string key)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    void IStorage.PersistStringValue(string value, string key)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    int IStorage.ReadIntValue(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    string IStorage.ReadStringValue(string key)
    {
        return PlayerPrefs.GetString(key);
    }

}
