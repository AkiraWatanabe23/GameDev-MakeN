using ECSCommons;

public class SoloGameSceneMain : IGameMain
{
    public void SetupMasterSystem(ref MasterSystem masterSystem, GameState gameState, NetworkMain networkMain)
    {
        masterSystem =
            new MasterSystem(
                networkMain,
                gameState,
                new DragSystem(),
                new CalculationSystem());
    }
}
