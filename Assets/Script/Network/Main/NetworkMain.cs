using Network;
using UnityEngine;

public class NetworkMain : MonoBehaviour
{
    [SubclassSelector]
    [SerializeReference]
    [SerializeField]
    private INetwork _network = default;

    public INetwork Network => _network;
    public bool IsConnected => Network.IsConnected;

    public ConnectionType ConnectType { get; private set; }

    public void SetUp()
    {
        _network.Initialize();

        if (_network is Client) { ConnectType = ConnectionType.Client; }
        else { ConnectType = ConnectionType.Server; }
    }

    private void OnDestroy() => _network?.OnDestroy();
}

public enum ConnectionType
{
    Client,
    Server,
}
