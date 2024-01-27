using ECSCommons;

public class GameSceneMain : IGameMain
{
    public void SetupMasterSystem(ref MasterSystem masterSystem, GameState gameState)
    {
        masterSystem =
            new MasterSystem(
                gameState,
                new ViewSystem(),
                new RandomNumberSystem());
    }
}
