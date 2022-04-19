using UnityEngine.UI;
using UnityEngine;

public class MainMenuScreen : MonoBehaviour
{

    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _recordsButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private RecodsScreen _recordsScreen;

    private RecordsDataProvider _dataProvider;
    private SceneLoader _sceneLoader;

    private void Start()
    {
        _sceneLoader = new SceneLoader();
        SetupDataProvider();
    }

    private void OnEnable()
    {
        _startGameButton.onClick.AddListener(StartGame);
        _recordsButton.onClick.AddListener(ShowRecordsScreen);
        _exitButton.onClick.AddListener(ExitGame);

        _recordsScreen.OnClickExitButton += RecordExitButtonClick;
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveListener(StartGame);
        _recordsButton.onClick.RemoveListener(ShowRecordsScreen);
        _exitButton.onClick.RemoveListener(ExitGame);

        _recordsScreen.OnClickExitButton -= RecordExitButtonClick;
    }

    private void SetupDataProvider()
    {
        _dataProvider = new RecordsDataProvider();
        var storage = new PlayerPrefsStorage();
        storage.SetupStorage();
        _dataProvider.SetupDataProvider(storage);
    }

    private void StartGame()
    {
        _sceneLoader.LoadGameScene();
    }

    private void ShowRecordsScreen()
    {
        var records = _dataProvider.GetRecords();
        _recordsScreen.Show(records);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    /// Records screen events
    private void RecordExitButtonClick()
    {
        _recordsScreen.Dismiss();
    }


}
