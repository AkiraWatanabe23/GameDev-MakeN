using Amazon;
using Amazon.GameLift;
using Amazon.GameLift.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Constants;
using Network;
using System;
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

    /// <summary> 接続処理 </summary>
    private bool Connect(ConnectionData connectionData)
    {
        try
        {
            _client = new(connectionData.IPAddress, connectionData.Port);
            var message = $"Connect : {connectionData.Serialize()}";

            Protocol.Send(_client, message);
            return true;
        }
        catch (Exception exception) { EditorLog.Error(exception.Message); return false; }
    }

    /// <summary> 接続終了 </summary>
    private void DisConnect()
    {
        if (_client == null) { EditorLog.Message("Client Instance not found"); return; }

        Protocol.Send(_client, DisConnectMessage);
        if (_client.Connected)
        {
            NetworkStream stream = _client.GetStream();
            stream.Close();
        }

        _client.Close();
        _client = null;
        EditorLog.Message("Client Disconnect Success");
    }

    /// <summary> 受信したメッセージを分析する </summary>
    private void MessageHandle(string message)
    {
        if (message == DisConnectMessage) { DisConnect(); }
    }

    public override void OnDestroy()
    {
        if (_client != null) { DisConnect(); }
    }
}

public class GameLiftClient
{
    public string AliasID { get; set; } = "Session";
    public string PlayerID { get; set; } = "";

    private PlayerSession _session = default;
    private AmazonGameLiftClient _gameLiftClient = default;

    /// <summary> ゲームクライアント初期化 </summary>
    public void CreateClient()
    {
        var config = new AmazonGameLiftConfig
        {
            RegionEndpoint = RegionEndpoint.USEast1
        };

        var nscf = new SharedCredentialsFile();
        nscf.TryGetProfile("ここにプロフィール名", out CredentialProfile profile);

        AWSCredentials credentials = profile.GetAWSCredentials(null);

        _gameLiftClient = new AmazonGameLiftClient(credentials, config);
    }

    /// <summary> ゲームセッションの作成 </summary>
    /// <returns> 作成したゲームセッションのインスタンス </returns>
    public GameSession CreateSession()
    {
        var cgsreq = new CreateGameSessionRequest
        {
            AliasId = AliasID,
            CreatorId = PlayerID,
            MaximumPlayerSessionCount = 4
        };

        CreateGameSessionResponse cgsres = _gameLiftClient.CreateGameSession(cgsreq);
        string gsid = cgsres.GameSession != null ? cgsres.GameSession.GameSessionId : "N/A";
        EditorLog.Message((int)cgsres.HttpStatusCode + " GAME SESSION CREATED: " + gsid);

        return cgsres.GameSession;
    }

    public PlayerSession CreatePlayerSession(GameSession gameSession)
    {
        var request = new CreatePlayerSessionRequest()
        {
            GameSessionId = gameSession.GameSessionId,
            PlayerId = PlayerID,
        };

        CreatePlayerSessionResponse response = _gameLiftClient.CreatePlayerSession(request);
        string psid = response.PlayerSession != null ? response.PlayerSession.PlayerSessionId : "N/A";
        
        return response.PlayerSession;
    }

    /// <summary> プレイヤーをゲームセッションに追加 </summary>
    /// <returns> 成功、失敗 </returns>
    public bool ConnectPlayer(int playerIndex, string sessionID)
    {
        return false;
        //return server.ConnectPlayer(playerIndex, sessionID);
    }

    public void DisconnectPlayer(int playerIndex)
    {

    }
}
