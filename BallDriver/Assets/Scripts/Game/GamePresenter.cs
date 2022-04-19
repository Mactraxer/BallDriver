using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] private DeadTrigger _deadTrigger;
    [SerializeField] private WinTrigger _winTrigger;
    [SerializeField] private LoseTrigger _loseTrigger;

    private RecordsDataProvider _dataProvider;
    private Timer _timer;
    private SceneLoader _sceneLoader;

    [SerializeField] private RecodsScreen _recordsScreen;

    private void Awake()
    {
        _sceneLoader = new SceneLoader();
        _timer = new Timer();
        SetupDataProvider();
    }

    private void SetupDataProvider()
    {
        _dataProvider = new RecordsDataProvider();
        var storage = new PlayerPrefsStorage();
        storage.SetupStorage();
        _dataProvider.SetupDataProvider(storage);
    }

    private void Start()
    {
        _timer.Record();    
    }

    private void OnEnable()
    {
        _deadTrigger.OnDetectObject += DeadTriggerFired;
        _winTrigger.OnDetectObject += WinTriggerFired;
        _loseTrigger.OnDetectObject += LoseTriggerFired;

        _recordsScreen.OnClickExitButton += ShowMainMenu;
        _recordsScreen.OnClickRestartButton += RestartGame;
           
    }

    private void OnDisable()
    {
        _deadTrigger.OnDetectObject -= DeadTriggerFired;
        _winTrigger.OnDetectObject -= WinTriggerFired;
        _loseTrigger.OnDetectObject -= LoseTriggerFired;

        _recordsScreen.OnClickExitButton -= ShowMainMenu;
        _recordsScreen.OnClickRestartButton -= RestartGame;
    }

    private void DeadTriggerFired(IDeadable destroyableObject)
    {
        destroyableObject.DestroySelf();
    }

    private void LoseTriggerFired(ILoseable winableObject)
    {
        winableObject.DestroySelf();

        var spentTime = _timer.Stop();
        ShowEndGameScreen($"You lose\nTimes spent = {spentTime}s");
    }

    private void WinTriggerFired(IWinable winableObject)
    {
        winableObject.DestroySelf();

        var timeRecord = _timer.Stop();
        SaveRecord(timeRecord);
        ShowEndGameScreen($"You win\nTimes spent = {timeRecord}s");
    }

    private void ShowEndGameScreen(string message)
    {
        var models = _dataProvider.GetRecords();
        _recordsScreen.Show(models, message);
    }
    
    private void SaveRecord(float time)
    {
        var model = new RecordDataModel("Developer", time);
        _dataProvider.SaveRecord(model);
    }
    
    private void StopGame()
    {

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
