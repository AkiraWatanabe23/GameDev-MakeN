using Constants;
using Network;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class NetworkMain : MonoBehaviour
{
    [SerializeField]
    private ConnectionType _connectionType = ConnectionType.Create;
    [SerializeField]
    private string _ipAddress = "";
    [SerializeField]
    private int _port = 0;

    [SerializeField]
    private InputField _addressInputField = default;
    [SerializeField]
    private Button _connectStartButton = default;

    private NetworkMastersystem _masterSystem = default;
    private NetworkMainUpdate _updateSystem = default;

    private NetworkClient _client = default;
    private NetworkServer _server = default;

    private void Awake()
    {
        _updateSystem = gameObject.TryGetComponent(out NetworkMainUpdate update) ? update : gameObject.AddComponent<NetworkMainUpdate>();

        _updateSystem.enabled = false;
    }

    private async void Start()
    {
        SetupUI();

        SetupMasterSystem();
        //Loaded();

        //await ConnectionStart();
        if (_connectionType == ConnectionType.Join) { await _server.Listen(); }
    }

    private void SetupMasterSystem()
    {
        _masterSystem = new();
        if (_connectionType == ConnectionType.Create) { _masterSystem.Initialize(_client = new NetworkClient()); }
        else if (_connectionType == ConnectionType.Join) { _masterSystem.Initialize(_server = new NetworkServer(_port)); }
        //_masterSystem.Initialize(_client = new NetworkClient(), new NetworkServer());
    }

    private void Loaded()
    {
        EditorLog.Message("Finish NetworkSystem Initialized");

        _updateSystem.SetupMasterSystem(_masterSystem);
        _updateSystem.enabled = true;
    }

    /// <summary> 通信開始 </summary>
    private void ConnectionStart()
    {
        if (_client == null) { EditorLog.Error("NetworkClient Instance not assigned"); return; }

        if (IPAddress.TryParse(_ipAddress, out IPAddress address)) { _client.Connect(address, _port); }
        else { _client.Connect(IPAddress.Any, _port); }
    }

    private void SetupUI()
    {
        if (_connectionType != ConnectionType.Create) { EditorLog.Message("You haven't to setup UI data"); return; }

        //if (_addressInputField != null) { _addressInputField.onEndEdit.AddListener(GetIPAddress); }
        if (_connectStartButton != null)
        {
            _connectStartButton.onClick.AddListener(() =>
            {
                ConnectionStart();
                Loaded();
            });
        }
    }

    private void OnDestroy() => _masterSystem?.OnDestroy();
}

public enum ConnectionType
{
    Create,
    Join,
}
