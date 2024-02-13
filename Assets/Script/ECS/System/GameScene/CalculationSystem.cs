using Constants;
using System;
using System.Data;

public class CalculationSystem : SystemBase
{
    private int _calcValue = 0;
    private CalcDataHolderComponent _player = default;

    private readonly DataTable _dataTable = new();

    public override void Initialize()
    {
        //初期値、計算記号の設定
        _player = GameState.Player;

        //数字の数分の長さの配列
        _player.Numbers = new int[GameState.NumbersCount];
        //式に入れられる計算記号の数は、「数字の数 - 1」
        _player.CalcSymbols = new CalculationSymbolType[GameState.NumbersCount - 1];

        for (int i = 0; i < _player.CalcSymbols.Length; i++) { _player.CalcSymbols[i] = GetRandomCalculationSymbol(); }

        ButtonsSetup();
    }

    public override void SetupEvent()
    {
        GameEvent.OnApplyFormula += ApplyFormula;
    }

    public override void OnDestroy()
    {
        GameEvent.OnApplyFormula -= ApplyFormula;
    }

    private void ButtonsSetup()
    {
        for (int i = 0; i < GameState.CalcButtons.Length; i++)
        {
            var calc = GameState.CalcButtons[i];

            calc.Init();
            calc.Button.onClick.AddListener(() =>
            {
                if (calc.ClickedMessage == "Reset") { _player.Formula = ""; }
                else if (calc.ClickedMessage == "=") { GameEvent.OnApplyFormula?.Invoke(); return; }
                else { _player.Formula += calc.ClickedMessage; }

                GameEvent.OnUpdateFormulaView?.Invoke(calc.ClickedMessage);
            });
        }
    }

    private void ApplyFormula()
    {
        GetCalcValue(_player.Formula);
        GameEvent.OnUpdateResultValueView?.Invoke(_calcValue);

        //ここにこれまでの入力のリセットを呼び出す
        GameEvent.OnUpdateFormulaView?.Invoke("Reset");
    }

    private int GetCalcValue(string formula)
    {
        // 数式の文字列からスペースを除去
        string sanitizedFormula = formula.Replace(" ", "");

        try
        {
            // 数式の結果を計算する
            _calcValue = EvaluateExpression(sanitizedFormula);
            EditorLog.Message($"計算結果：{formula} = {_calcValue}");
        }
        catch (Exception exception) { EditorLog.Error(exception.Message); return _calcValue = int.MinValue; }

        return _calcValue;
    }

    private int EvaluateExpression(string expression)
    {
        // 数式の計算結果を取得する
        object result = _dataTable.Compute(expression, "");

        // 計算結果を整数に変換して返す
        return int.Parse(result.ToString());
    }

    private CalculationSymbolType GetRandomCalculationSymbol()
    {
        var random = UnityEngine.Random.Range(1, 5);
        return random switch
        {
            1 => CalculationSymbolType.Addition,
            2 => CalculationSymbolType.Subtraction,
            3 => CalculationSymbolType.Multiplication,
            4 => CalculationSymbolType.Division,
            _ => CalculationSymbolType.None
        };
    }
}

public enum CalculationSymbolType
{
    None,
    Addition,
    Subtraction,
    Multiplication,
    Division,
}
