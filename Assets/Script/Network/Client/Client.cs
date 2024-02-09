using Constants;
using Network;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Client : INetwork
{
    [SerializeField]
    private int _port = 0;

    #region UI
    [SerializeField]
    private InputField _addressInputField = default;
    [SerializeField]
    private Button _connectStartButton = default;
    #endregion

    private NetworkClient _client = default;
    private IPAddress _ipAddress = IPAddress.Any;

    public NetworkBase Network { get; set; }
    public bool IsConnected => Network.IsConnected;

    public void Initialize()
    {
        _client = new();
        Network = _client;

        SetupUI();
    }

    public void OnDestroy() => _client?.OnDestroy();

    private void SetupUI()
    {
        if (_connectStartButton != null)
        {
            _connectStartButton.onClick.AddListener(() =>
            {
                _ipAddress = GetAddress(_addressInputField.text);

                EditorLog.Message($"{_ipAddress == IPAddress.Any} {_ipAddress}");
                ConnectionStart();
            });
        }
    }

    /// <summary> 通信開始 </summary>
    private void ConnectionStart()
    {
        if (_client == null) { EditorLog.Error("NetworkClient Instance not assigned"); return; }

        _client.Connect(_ipAddress, _port);
    }

    private IPAddress GetAddress(string text)
    {
        if (IPAddress.TryParse(text, out IPAddress iPAddress)) { return iPAddress; }

        var host = Dns.GetHostEntry(Dns.GetHostName());
        EditorLog.Message(host.HostName);

        var address = Dns.GetHostAddresses(host.HostName);
        foreach (var addressEntry in address)
        {
            EditorLog.Message(addressEntry.ToString());
        }

        var android = Dns.GetHostEntry("192.168.0.13");
        EditorLog.Message(android.HostName);

        return IPAddress.Any;
    }
}
