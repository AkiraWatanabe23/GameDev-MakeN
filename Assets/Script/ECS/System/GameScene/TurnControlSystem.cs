using Constants;
using Network;

public class TurnControlSystem : SystemBase
{
    public override void SetupEvent()
    {
        GameEvent.OnTurnChange += TurnChange;
    }

    public override void OnDestroy()
    {
        GameEvent.OnTurnChange -= TurnChange;
    }

    private void TurnStart()
    {
        if (GameState.CurrentTurn == Turn.None) { GameState.CurrentTurn = Turn.Player1; return; }
    }

    private void TurnEnd()
    {
        //ここで自分の番が終了したことを相手に伝える
        NetworkEvent.OnSendData?.Invoke("Turn End");
    }

    private void TurnChange(Turn next)
    {
        if (GameState.CurrentTurn == next) { EditorLog.Message("No Change Turn"); return; }

        GameState.CurrentTurn = next;
    }
}

public enum Turn
{
    None,
    Player1,
    Player2
}
