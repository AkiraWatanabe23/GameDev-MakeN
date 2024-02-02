using ECSCommons;

public class ServerGameSceneMain : IGameMain
{
    public void SetupMasterSystem(ref MasterSystem masterSystem, GameState gameState)
    {
        masterSystem =
            new MasterSystem(
                gameState,
                new TurnControlSystem(),
                new ServerViewSystem());
    }
}
