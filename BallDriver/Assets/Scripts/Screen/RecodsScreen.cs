using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RecodsScreen : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Text _endGameReason;
    [SerializeField] private ScrollRect _recordsScrollRect;
    [SerializeField] private GameObject _recordTextPrefab;

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private List<RecordDataModel> _recordModels;

    public Action OnClickRestartButton;
    public Action OnClickExitButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartAction);
        _exitButton.onClick.AddListener(ExitAction);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartAction);
        _exitButton.onClick.RemoveListener(ExitAction);
    }

    public void Show(List<RecordDataModel> records, string endGameReason = "")
    {
        _endGameReason.text = endGameReason;

        _panel.SetActive(true);

        _recordModels = records;
        SortRecords();
        DisplayData(_recordModels);
    }

    public void Dismiss()
    {
        _panel.SetActive(false);
    }

    private void SortRecords()
    {
        _recordModels.Sort((x, y) => x.Time.CompareTo(y.Time));
    }

    private void DisplayData(List<RecordDataModel> records)
    {
        if (records.Count == 0) { DisplayEmptyRecords(); return; }

        foreach (var item in records)
        {
            GameObject record = Instantiate(_recordTextPrefab, _recordsScrollRect.content);

            var recordText = record.GetComponent<Text>();
            recordText.text = String.Format("{0} = {1:f}s", item.RecordHolderName, item.Time);           
        }
        
    }

    private void DisplayEmptyRecords()
    {
        GameObject record = Instantiate(_recordTextPrefab, _recordsScrollRect.content);

        var recordText = record.GetComponent<Text>();
        recordText.text = "Records list is empty";
    }

    private void RestartAction()
    {
        OnClickRestartButton?.Invoke();
    }

    private void ExitAction()
    {
        OnClickExitButton?.Invoke();
    }

}
