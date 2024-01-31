using Constants;
using Network;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

public class NetworkServer : NetworkBase
{
    private TcpListener _listener = default;
    private TcpClient _client = null;

    private readonly int _port = 0;

    public NetworkServer(int port) => _port = port;

    /// <summary> 接続待機 </summary>
    public async Task Listen()
    {
        _listener = new(IPAddress.Any, _port);

        _listener.Start();
        EditorLog.Message("Listen start");

        try
        {
            _client = await _listener.AcceptTcpClientAsync();
            GetMessageAsync();
        }
        catch (SocketException exception) { EditorLog.Error(exception.Message); }
        catch (Exception exception) { EditorLog.Error(exception.Message); }
    }

    private void GetMessageAsync()
    {
        EditorLog.Message("接続されました");

        Protocol.ReceiveAsync(_client.GetStream());
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
