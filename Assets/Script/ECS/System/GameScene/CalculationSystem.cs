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
        //式に含まれる要素：数字、計算記号、数をくくる括弧
        //n個の数がある計算式で想定される括弧の数は最大で「2^（n - 1）個」
        _player.FromulaArray = new string[(int)Math.Pow(2, GameState.NumbersCount - 1) + GameState.NumbersCount * 2 - 1];

        for (int i = 0; i < _player.CalcSymbols.Length; i++) { _player.CalcSymbols[i] = GetRandomCalculationSymbol(); }
    }

    public override void SetupEvent()
    {
        GameEvent.OnApplyFormula += ApplyFormula;
    }

    private void ApplyFormula()
    {
        if (TryParse2Formula(out string formula)) { EditorLog.Message("式が成り立っていません"); return; }

        EditorLog.Message($"計算結果：{formula} = {_calcValue}");
    }

    private bool TryParse2Formula(out string formula)
    {
        var line = "";
        Array.ForEach(_player.FromulaArray, calcElement => line += calcElement);

        _calcValue = GetCalcValue(line);
        if (_calcValue <= int.MinValue)
        {
            formula = "";
            return false;
        }

        formula = line;
        return true;
    }

    private int GetCalcValue(string formula)
    {
        // 数式の文字列からスペースを除去
        string sanitizedFormula = formula.Replace(" ", "");
        int result = 0;

        try
        {
            // 数式の結果を計算する
            result = EvaluateExpression(sanitizedFormula);
        }
        catch (Exception exception) { EditorLog.Error(exception.Message); return int.MinValue; }

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
