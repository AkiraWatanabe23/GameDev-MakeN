using ECSCommons;
using Network;

public abstract class SystemBase
{
    public MasterSystem MasterSystem { get; set; }
    public GameEvent GameEvent { get; set; }
    public GameState GameState { get; set; }
    public NetworkEvent NetworkEvent { get; set; }

    public virtual void Initialize() { }
    public virtual void SetupEvent() { }
    public virtual void OnDestroy() { }
}