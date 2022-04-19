using UnityEngine.UI;
using UnityEngine;
using System;

public class EnterNameScreen : MonoBehaviour
{

    [SerializeField] private InputField _inputField;
    [SerializeField] private Button _saveButton;

    private NameDataProvider _dataProvider;

    public Action OnClickedSaveButton;

    private void OnEnable()
    {
        _saveButton.onClick.AddListener(SaveName);    
    }

    private void OnDisable()
    {
        _saveButton.onClick.RemoveListener(SaveName);
    }

    private void Start()
    {
        _dataProvider = new NameDataProvider(new PlayerPrefsStorage());
    }

    private void SaveName()
    {
        _dataProvider.SetName(_inputField.text);
        OnClickedSaveButton?.Invoke();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Dismiss()
    {
        gameObject.SetActive(false);
    }



}
