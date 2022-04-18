using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RecodsScreen : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Text _endGameReason;
    [SerializeField] private ScrollRect _recordsScrollRect;

    public void Show(List<RecordDataModel> records, string endGameReason = "")
    {
        if (endGameReason.Length > 0)
        {
            _endGameReason.text = endGameReason;
        }

        _panel.SetActive(true);
        DisplayData(records);
    }

    public void Dismiss()
    {
        _panel.SetActive(false);
    }

    private void DisplayData(List<RecordDataModel> records)
    {

        foreach (var item in records)
        {
            GameObject record = new GameObject();
            Text recordText = record.AddComponent<Text>();
            recordText.text = $"{item.RecordHolderName} = {item.Time}s";
            recordText.fontSize = 20;
            record.transform.parent = _recordsScrollRect.transform;
        }
        
    }
}
