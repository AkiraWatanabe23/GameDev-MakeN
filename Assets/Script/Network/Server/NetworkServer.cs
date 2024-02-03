using Constants;
using Network;
using System;
using System.Net;
using System.Net.Sockets;

public class NetworkServer : NetworkBase
{
    private TcpListener _listener = default;
    private NetworkStream _stream = default;
    private bool _isConnected = false;

    private readonly int _port = 0;

    public override NetworkStream Stream => _stream;
    public override bool IsConnected => _isConnected;

    public NetworkServer(int port) => _port = port;

    /// <summary> 接続開始 </summary>
    public void Listen(IPAddress iPAddress)
    {
        _listener = new(iPAddress, _port);

        _listener.Start();
        _listener.BeginAcceptSocket(AcceptClientCallback, _listener);
        EditorLog.Message("Listen start");
    }

    /// <summary> 接続時に呼ばれるコールバック </summary>
    private void AcceptClientCallback(IAsyncResult result)
    {
        EditorLog.Message("接続されました");
        _isConnected = true;

        var listener = (TcpListener)result.AsyncState;
        var client = listener.EndAcceptTcpClient(result);

        GetMessageAsync(client);
    }

    /// <summary> 接続成功時以降実行される </summary>
    private void GetMessageAsync(TcpClient client)
    {
        while (client.Connected)
        {
            _stream = client.GetStream();
            var text = Protocol.ReceiveAsync(_stream);
            EditorLog.Message(text.ToString());
        }
    }

    public override void DisConnected()
    {
        _isConnected = false;
    }

    public override void OnDestroy()
    {
        _listener?.Stop();
    }
}
