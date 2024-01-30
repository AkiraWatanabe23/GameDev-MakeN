using Constants;
using Network;
using System.Net;
using System.Net.Sockets;

public class NetworkServer : NetworkBase
{
    private TcpListener _listener = default;
    private TcpClient _client = null;

    /// <summary> 接続待機 </summary>
    public async void Listen()
    {
        _listener = new(IPAddress.Any, 9007);

        _listener.Start();
        EditorLog.Message("Listen start");

        _client = await _listener.AcceptTcpClientAsync();
        GetMessageAsync();
    }

    private void GetMessageAsync()
    {
        EditorLog.Message("接続されました");

        var stream = _client.GetStream();
        Protocol.ReceiveAsync(stream);
    }

    public override void OnDestroy()
    {
        _listener?.Stop();
        _client?.Close();
    }
}

public class GameLiftServer
{

}
