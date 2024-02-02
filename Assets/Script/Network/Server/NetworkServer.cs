using Constants;
using Network;
using System;
using System.Net;
using System.Net.Sockets;

public class NetworkServer : NetworkBase
{
    private TcpListener _listener = default;

    private readonly int _port = 0;

    public NetworkServer(int port) => _port = port;

    /// <summary> 接続待機 </summary>
    public void Listen(IPAddress iPAddress)
    {
        _listener = new(iPAddress, _port);

        _listener.Start();
        _listener.BeginAcceptSocket(AcceptClientCallback, _listener);
        EditorLog.Message("Listen start");
    }

    private void AcceptClientCallback(IAsyncResult result)
    {
        var listener = (TcpListener)result.AsyncState;
        var client = listener.EndAcceptTcpClient(result);

        GetMessageAsync(client);
    }

    private void GetMessageAsync(TcpClient client)
    {
        EditorLog.Message("接続されました");
        while (client.Connected)
        {
            var text = Protocol.ReceiveAsync(client.GetStream());
            EditorLog.Message(text.ToString());
        }
    }

    private void SendMessageToClient(TcpClient client, string message)
    {
        Protocol.SendAsync(client.GetStream(), message);
    }

    public override void OnDestroy()
    {
        _listener?.Stop();
    }
}

public class GameLiftServer
{

}
