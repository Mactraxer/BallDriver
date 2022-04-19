using UnityEngine.UI;
using UnityEngine;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private Text _enterNameText;
    [SerializeField] private Button _enterNameButton;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _recordsButton;

    [SerializeField] private EnterNameScreen _enterNameScreen;
    [SerializeField] private RecodsScreen _recordsScreen;

    private RecordsDataProvider _recordsDataProvider;
    private NameDataProvider _nameDataProvider;

    private SceneLoader _sceneLoader;

    private void Start()
    {
        _sceneLoader = new SceneLoader();
        SetupDataProvider();
        SetupNameText();
    }

    private void OnEnable()
    {
        _startGameButton.onClick.AddListener(StartGame);
        _recordsButton.onClick.AddListener(ShowRecordsScreen);
        _enterNameButton.onClick.AddListener(ShowEnterNameScreen);

        _recordsScreen.OnClickExitButton += RecordExitButtonClick;
        _enterNameScreen.OnClickedSaveButton += SaveButtonClick;
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveListener(StartGame);
        _recordsButton.onClick.RemoveListener(ShowRecordsScreen);
        _enterNameButton.onClick.RemoveListener(ShowEnterNameScreen);

        _recordsScreen.OnClickExitButton -= RecordExitButtonClick;
        _enterNameScreen.OnClickedSaveButton -= SaveButtonClick;
    }

    private void SetupDataProvider()
    {
        _recordsDataProvider = new RecordsDataProvider(new PlayerPrefsStorage());
        _nameDataProvider = new NameDataProvider(new PlayerPrefsStorage());
    }

    private void SetupNameText()
    {
        var name = _nameDataProvider.GetName();

        if (name == "")
        {
            _enterNameText.text = "You name is None";
            _nameDataProvider.SetName("None");
        }
        else
        {
            _enterNameText.text = $"You name is {name}";
        }
    }

    private void ShowEnterNameScreen()
    {
        _enterNameScreen.Show();
    }

    private void StartGame()
    {
        _sceneLoader.LoadGameScene();
    }

    private void ShowRecordsScreen()
    {
        var records = _recordsDataProvider.GetRecords();
        _recordsScreen.Show(records);
    }

    /// Records screen event
    private void RecordExitButtonClick()
    {
        _recordsScreen.Dismiss();
    }

    /// Enter name screen event
    private void SaveButtonClick()
    {
        SetupNameText();
        _enterNameScreen.Dismiss();
    }

}
