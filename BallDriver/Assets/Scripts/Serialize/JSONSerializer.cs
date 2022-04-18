using UnityEngine;

public class JSONSerializer
{
    
    public string ConvertToJSON(object model)
    {
        return JsonUtility.ToJson(model);
    }

    public T ConvertFromJSON<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }

}
