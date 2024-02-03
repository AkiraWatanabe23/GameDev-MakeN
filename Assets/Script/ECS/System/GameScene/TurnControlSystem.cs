using Constants;
using Network;

public class TurnControlSystem : SystemBase
{
    public override void SetupEvent()
    {
        GameEvent.OnTurnStart += TurnStart;
        GameEvent.OnTurnEnd += TurnEnd;
    }

    public override void OnDestroy()
    {
        GameEvent.OnTurnStart -= TurnStart;
        GameEvent.OnTurnEnd -= TurnEnd;
    }

    private void TurnStart()
    {
        if (GameState.CurrentTurn == Turn.None) { GameState.CurrentTurn = Turn.Player1; return; }
    }

    private void TurnEnd()
    {
        //ここで自分の番が終了したことを相手に伝える
        Protocol.SendAsync(Stream, "Turn End");

        TurnChange(GameState.CurrentTurn == Turn.Player1 ? Turn.Player2 : Turn.Player1);
        GameEvent.OnTurnStart?.Invoke();
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
