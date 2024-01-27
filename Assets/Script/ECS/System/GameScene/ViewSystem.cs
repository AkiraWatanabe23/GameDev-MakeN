using DG.Tweening;
using ECSCommons;
using UnityEngine;
using UnityEngine.UI;

public class ViewSystem : SystemBase
{
    public override void Initialize()
    {
        GameEvent.OnGetRandomNumberForRange?.Invoke(10, 200);
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

    private void TextMove(Text target, Vector2 to, float duration) => target.rectTransform.DOAnchorPos(to, duration).SetEase(Ease.Linear);
}
