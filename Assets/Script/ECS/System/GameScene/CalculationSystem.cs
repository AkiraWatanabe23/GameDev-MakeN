using Constants;
using System.Data;

public class CalculationSystem : SystemBase
{
    private CalcDataHolderComponent _player = default;

    private readonly DataTable _dataTable = new();

    public override void Initialize()
    {
        //初期値、計算記号の設定
        _player = GameState.Player;

        _player.Numbers = new int[GameState.NumbersCount];
        _player.CalcSymbols = new CalculationSymbolType[GameState.NumbersCount - 1];

        for (int i = 0; i < _player.CalcSymbols.Length; i++) { _player.CalcSymbols[i] = GetRandomCalculationSymbol(); }
    }

    public override void SetupEvent()
    {
        GameEvent.OnApplyFormula += ApplyFormula;
    }

    private void ApplyFormula()
    {
        if (TryParse2Formula(out string formula)) { EditorLog.Message("式が成り立っていません"); return; }

        var value = GetCalcValue(formula);
    }

    private bool TryParse2Formula(out string formula)
    {
        formula = "";
        return false;
    }

    private int GetCalcValue(string formula)
    {
        // 数式の文字列からスペースを除去
        string sanitizedFormula = formula.Replace(" ", "");

        // 数式の結果を計算する
        int result = EvaluateExpression(sanitizedFormula);

        return result;
    }

    private int EvaluateExpression(string expression)
    {
        // 数式の計算結果を取得する
        object result = _dataTable.Compute(expression, "");

        // 計算結果を整数に変換して返す
        return int.Parse(result.ToString());
    }

    private string ConvertCalcSymbol(CalculationSymbolType symbol)
    {
        return symbol switch
        {
            CalculationSymbolType.Addition => "+",
            CalculationSymbolType.Subtraction => "-",
            CalculationSymbolType.Multiplication => ":",
            CalculationSymbolType.Division => "/",
            _ => ""
        };
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
