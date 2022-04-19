using UnityEngine;
using UnityEngine.UI;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] private DeadTrigger _deadTrigger;
    [SerializeField] private WinTrigger _winTrigger;
    [SerializeField] private LoseTrigger _loseTrigger;

    [SerializeField] private SystemInput _input;

    private RecordsDataProvider _recordsDataProvider;
    private NameDataProvider _nameDataProvider;

    private Timer _timer;
    private SceneLoader _sceneLoader;

    private string _playerName;

    [SerializeField] private RecodsScreen _recordsScreen;
    [SerializeField] private Text _timeText;
    [SerializeField] private GameObject _infoPanel;

    private void Awake()
    {
        _sceneLoader = new SceneLoader();
        _timer = new Timer();
        SetupDataProvider();
    }

    private void SetupDataProvider()
    {
        _recordsDataProvider = new RecordsDataProvider(new PlayerPrefsStorage());
        _nameDataProvider = new NameDataProvider(new PlayerPrefsStorage());
    }

    private void Start()
    {
        _timer.Record();
        _playerName = _nameDataProvider.GetName();
    }

    private void OnEnable()
    {
        _deadTrigger.OnDetectObject += DeadTriggerFired;
        _winTrigger.OnDetectObject += WinTriggerFired;
        _loseTrigger.OnDetectObject += LoseTriggerFired;

        _input.OnInputPause += StopGame;

        _recordsScreen.OnClickExitButton += ShowMainMenu;
        _recordsScreen.OnClickRestartButton += RestartGame;
           
    }

    private void OnDisable()
    {
        _deadTrigger.OnDetectObject -= DeadTriggerFired;
        _winTrigger.OnDetectObject -= WinTriggerFired;
        _loseTrigger.OnDetectObject -= LoseTriggerFired;

        _input.OnInputPause -= StopGame;

        _recordsScreen.OnClickExitButton -= ShowMainMenu;
        _recordsScreen.OnClickRestartButton -= RestartGame;
    }

    private void FixedUpdate()
    {
        _timeText.text = string.Format("Time = {0:f}s", _timer.CurrentTime);
    }

    private void DeadTriggerFired(IDeadable destroyableObject)
    {
        destroyableObject.DestroySelf();
    }

    private void LoseTriggerFired(ILoseable winableObject)
    {
        winableObject.DestroySelf();

        var spentTime = _timer.Stop();
        ShowEndGameScreen(string.Format("You lose\nTimes spent = {0:f}s", spentTime));
    }

    private void WinTriggerFired(IWinable winableObject)
    {
        winableObject.DestroySelf();

        var timeRecord = _timer.Stop();
        SaveRecord(timeRecord);
        ShowEndGameScreen(string.Format("You win\nTimes spent = {0:f}s", timeRecord));
    }

    private void ShowEndGameScreen(string message)
    {
        _timeText.enabled = false;
        _infoPanel.SetActive(false);

        var models = _recordsDataProvider.GetRecords();
        _recordsScreen.Show(models, message);
    }
    
    private void SaveRecord(float time)
    {
        var model = new RecordDataModel(_playerName, time);
        _recordsDataProvider.SaveRecord(model);
    }
    
    private void StopGame()
    {
        ShowMainMenu();
    }

    private void RestartGame()
    {
        _sceneLoader.LoadGameScene();
    }

    private void ShowMainMenu()
    {
        _sceneLoader.LoadMainMenuScene();
    }

}
