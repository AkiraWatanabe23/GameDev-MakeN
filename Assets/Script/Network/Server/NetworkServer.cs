using Constants;
using Network;
using System;
using System.Net;
using System.Net.Sockets;

public class NetworkServer : NetworkBase
{
    private IPEndPoint _remoteEP = default;
    private TcpListener _listener = default;

    public void Listen()
    {
        _remoteEP = new(IPAddress.Any, 9007);
        _listener = new(_remoteEP);

        _listener.Start();
        var client = _listener.AcceptTcpClient();

        var stream = client.GetStream();
        GetData(stream);
    }

    private void GetData(NetworkStream stream)
    {
        var data = new Byte[256];

        var bytes = stream.Read(data, 0, data.Length);
        var responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);

        EditorLog.Message(responseData);
    }
}

public class GameLiftServer
{

}
