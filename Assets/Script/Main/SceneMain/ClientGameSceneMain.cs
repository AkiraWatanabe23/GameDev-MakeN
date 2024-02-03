using ECSCommons;

public class ClientGameSceneMain : IGameMain
{
    public void SetupMasterSystem(ref MasterSystem masterSystem, GameState gameState, NetworkMain networkMain)
    {
        masterSystem =
            new MasterSystem(
                networkMain,
                gameState,
                new TurnControlSystem(),
                new RandomNumberSystem(),
                new ClientViewSystem());
    }
}
