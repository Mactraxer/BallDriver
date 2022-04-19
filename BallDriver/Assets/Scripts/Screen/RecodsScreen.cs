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
            GameObject record = Instantiate(_recordTextPrefab, _recordsScrollRect.content);

            var recordText = record.GetComponent<Text>();
            recordText.text = $"{item.RecordHolderName} = {item.Time}s";           
        }
        
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
