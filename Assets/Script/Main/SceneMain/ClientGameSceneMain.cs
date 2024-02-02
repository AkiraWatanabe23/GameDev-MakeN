using ECSCommons;

public class ClientGameSceneMain : IGameMain
{
    public void SetupMasterSystem(ref MasterSystem masterSystem, GameState gameState)
    {
        masterSystem =
            new MasterSystem(
                gameState,
                new TurnControlSystem(),
                new RandomNumberSystem(),
                new ClientViewSystem());
    }
}
