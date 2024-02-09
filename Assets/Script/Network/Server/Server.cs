using Constants;
using Network;
using System.Net;
using UnityEngine;

public class Server : INetwork
{
    [SerializeField]
    private int _port = 0;

    private NetworkServer _server = default;

    public NetworkBase Network { get; set; }
    public bool IsConnected => Network.IsConnected;

    public void Initialize()
    {
        _server = new(_port);
        Network = _server;

        _server.Listen(IPAddress.Any);
    }

    public void OnDestroy() => _server?.OnDestroy();
}
