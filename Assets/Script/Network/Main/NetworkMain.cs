using Network;
using UnityEngine;

public class NetworkMain : MonoBehaviour
{
    [SubclassSelector]
    [SerializeReference]
    [SerializeField]
    private INetwork _networkType = default;

    public INetwork NetworkType => _networkType;
    public bool IsConnected => NetworkType.IsConnected;

    public ConnectionType ConnectType { get; private set; }

    private void Start() => Setup();

    private void Setup()
    {
        _networkType.Initialize();

        if (_networkType is Client) { ConnectType = ConnectionType.Client; }
        else { ConnectType = ConnectionType.Server; }
    }

    private void OnDestroy() => _networkType?.OnDestroy();
}

public enum ConnectionType
{
    Client,
    Server,
}
