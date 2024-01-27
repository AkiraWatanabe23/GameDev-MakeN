using Constants;
using Network;
using System.Net.Sockets;

public class NetworkClient : NetworkBase
{
    private TcpClient _client = default;

    private const string DisConnectMessage = "DisConnect";

    public override async void OnUpdate()
    {
        if (_client == null) { EditorLog.Error("Client Instance not found"); return; }

        var messages = await Protocol.Receive(_client);
        foreach (var message in messages) { MessageHandle(message); }
    }

    private void Connect()
    {

    }

    private void DisConnect()
    {
        if (_client == null) { EditorLog.Message("Client Instance not found"); return; }

        if (_client.Connected)
        {
            NetworkStream stream = _client.GetStream();
            stream.Close();
        }

        _client.Close();
        _client = null;
    }

    /// <summary> 受信したメッセージを分析する </summary>
    private void MessageHandle(string message)
    {
        if (message == DisConnectMessage) { DisConnect(); }
    }

    public override void OnDestroy()
    {
        if ( _client != null ) { DisConnect(); }
    }
}
