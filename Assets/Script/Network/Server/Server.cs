using Network;
using System.Net;
using UnityEngine;

public class Server : INetwork
{
    [SerializeField]
    private int _port = 0;

    private NetworkServer _server = default;

    public void Initialize()
    {
        _server = new(_port);

        _server.Listen(IPAddress.Any);
    }

    public void OnDestroy() => _server?.OnDestroy();
}
