using ECSCommons;

public class ServerGameSceneMain : IGameMain
{
    public void SetupMasterSystem(ref MasterSystem masterSystem, GameState gameState, NetworkMain networkMain)
    {
        masterSystem =
            new MasterSystem(
                networkMain,
                gameState,
                new TurnControlSystem(),
                new ServerViewSystem());
    }
}
