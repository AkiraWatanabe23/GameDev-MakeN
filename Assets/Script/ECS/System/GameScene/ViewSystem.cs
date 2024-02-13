using DG.Tweening;
using ECSCommons;

public class ViewSystem : SystemBase
{
    private ViewComponent _view = default;

    public override void Initialize()
    {
        _view = GameState.ViewComponent;

        //GameEvent.OnNumberView?.Invoke(GameState.TargetValue, 2f);
        GameEvent.OnUpdateFormulaView?.Invoke("Reset");
    }

    public override void SetupEvent()
    {
        GameEvent.OnNumberView += NumberView;
        GameEvent.OnUpdateResultValueView += UpdateResultValue;
        GameEvent.OnUpdateFormulaView += UpdateFormula;
    }

    public override void OnDestroy()
    {
        GameEvent.OnNumberView -= NumberView;
        GameEvent.OnUpdateResultValueView -= UpdateResultValue;
        GameEvent.OnUpdateFormulaView -= UpdateFormula;
    }

    private void NumberView(int value, float duration = 1f)
    {
        _view.TargetNumberText.text = "";
        _view.TargetNumberText
            .DOText(value.ToString(), duration, scrambleMode: ScrambleMode.Numerals)
            .SetEase(Ease.Linear);
    }

    private void UpdateFormula(string message)
    {
        if (message == "Reset") { _view.FormulaText.text = ""; }
        else { _view.FormulaText.text += message; }
    }

    private void UpdateResultValue(int value) => _view.TargetNumberText.text = value.ToString();
}
