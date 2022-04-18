using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] private EnterTrigger _deadTrigger;
    [SerializeField] private EnterTrigger _winTrigger;

    private RecordsDataProvider _dataProvider;
    private Timer _timer;

    [SerializeField] private RecodsScreen _recordsScreen;

    private void Awake()
    {
        _timer = new Timer();
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
        _deadTrigger.OnDetectObject += DestroyObject;
        _winTrigger.OnDetectObject += ShowWinScreen;
    }

    private void OnDisable()
    {
        _deadTrigger.OnDetectObject -= DestroyObject;
        _winTrigger.OnDetectObject -= ShowWinScreen;
    }

    private void DestroyObject(GameObject gameObject)
    {
        _timer.Stop();
        Destroy(gameObject);
    }

    private void ShowWinScreen(GameObject gameObject)
    {
        var timeRecord = _timer.Stop();
        var model = new RecordDataModel("Developer", timeRecord);
        _dataProvider.SaveRecord(model);
        print($"U win!!!!U time = {timeRecord}s");

        var models = _dataProvider.GetRecords();
        _recordsScreen.Show(models ,"Win");
    }

}
