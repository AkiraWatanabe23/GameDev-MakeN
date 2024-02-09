using DG.Tweening;
using ECSCommons;

public class ViewSystem : SystemBase
{
    public override void Initialize()
    {
        GameEvent.OnNumberView?.Invoke(GameState.TargetValue, 2f);
    }

    public override void SetupEvent()
    {
        GameEvent.OnNumberView += NumberView;
    }

    public override void OnDestroy()
    {
        GameEvent.OnNumberView -= NumberView;
    }

    private void NumberView(int value, float duration = 1f)
    {
        GameState.ViewComponent.TargetNumberText.text = "";
        GameState.ViewComponent.TargetNumberText
            .DOText(value.ToString(), duration, scrambleMode: ScrambleMode.Numerals)
            .SetEase(Ease.Linear);
    }
}
