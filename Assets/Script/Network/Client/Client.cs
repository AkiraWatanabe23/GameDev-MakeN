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

    public void Initialize()
    {
        _client = new();
        SetupUI();
    }

    public void OnDestroy() => _client?.OnDestroy();

    /// <summary> 通信開始 </summary>
    private void ConnectionStart()
    {
        if (_client == null) { EditorLog.Error("NetworkClient Instance not assigned"); return; }

        _client.Connect(_ipAddress, _port);
    }

    private void SetupUI()
    {
        if (_connectStartButton != null)
        {
            _connectStartButton.onClick.AddListener(() =>
            {
                _ipAddress = GetAddress(_addressInputField.text);

                EditorLog.Message(_ipAddress.ToString());
                ConnectionStart();
            });
        }
    }

    private IPAddress GetAddress(string text)
        => IPAddress.TryParse(text, out IPAddress iPAddress) ? iPAddress : IPAddress.Any;
}
