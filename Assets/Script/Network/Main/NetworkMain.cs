using Constants;
using Network;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class NetworkMain : MonoBehaviour
{
    [SerializeField]
    private ConnectionType _connectionType = ConnectionType.Create;

    [SerializeField]
    private InputField _addressInputField = default;
    [SerializeField]
    private Button _connectStartButton = default;

    [SerializeField]
    private ConnectionData _connectionData = default;

    private NetworkMastersystem _masterSystem = default;
    private NetworkMainUpdate _updateSystem = default;

    private NetworkClient _client = default;

    private string _ipAddress = default;
    
    private void Awake()
    {
        _updateSystem = gameObject.TryGetComponent(out NetworkMainUpdate update) ? update : gameObject.AddComponent<NetworkMainUpdate>();

        _updateSystem.enabled = false;
    }

    private void Start()
    {
        SetupUI();

        SetupMasterSystem();
        //Loaded();

        //await ConnectionStart();
    }

    private void SetupMasterSystem()
    {
        _masterSystem = new();
        if (_connectionType == ConnectionType.Create) { _masterSystem.Initialize(_client = new NetworkClient()); }
        else if (_connectionType == ConnectionType.Join) { _masterSystem.Initialize(new NetworkServer()); }
        //_masterSystem.Initialize(_client = new NetworkClient(), new NetworkServer());
    }

    private void Loaded()
    {
        EditorLog.Message("Finish NetworkSystem Initialized");

        _updateSystem.SetupMasterSystem(_masterSystem);
        _updateSystem.enabled = true;
    }

    /// <summary> 通信開始 </summary>
    private async Task ConnectionStart()
    {
        if (_client == null) { EditorLog.Error("NetworkClient Instance not assigned"); return; }
        if (_connectionData == null) { EditorLog.Error("ConnectionData not assigned"); return; }

        _connectionData.IPAddress = _ipAddress;

        _client.Connect(_connectionData);
        await Task.Yield();
    }

    private void SetupUI()
    {
        if (_connectionType != ConnectionType.Create) { EditorLog.Message("You haven't to setup UI data"); return; }

        if (_addressInputField != null) { _addressInputField.onEndEdit.AddListener(GetIPAddress); }
        if (_connectStartButton != null)
        {
            _connectStartButton.onClick.AddListener(async () =>
            {
                await ConnectionStart();
                Loaded();
            });
        }
    }

    private void GetIPAddress(string data) => _ipAddress = data;

    private void OnDestroy() => _masterSystem?.OnDestroy();
}

public enum ConnectionType
{
    Create,
    Join,
}
