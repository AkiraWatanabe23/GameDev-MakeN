using Constants;
using System;
using System.Data;
using UnityEngine;

public class Calculation : MonoBehaviour
{
    [SerializeField]
    private string _formula = "2 + 3 * (6 + 1)";

    private void Start()
    {
        Calculator calculator = new();

        // 数式を計算し、結果を取得
        int result = calculator.GetValue(_formula);

        // 結果を出力
        EditorLog.Message("計算結果: " + result);
    }
}

[Serializable]
public class Calculator
{
    public int GetValue(string formula)
    {
        // 数式の文字列からスペースを除去
        string sanitizedFormula = formula.Replace(" ", "");

        // 数式の結果を計算する
        int result = EvaluateExpression(sanitizedFormula);

        return result;
    }

    private int EvaluateExpression(string expression)
    {
        // 数式を計算するためのDataTableを生成
        DataTable dataTable = new DataTable();
        // 数式の計算結果を取得する
        object result = dataTable.Compute(expression, "");

        // 計算結果を整数に変換して返す
        return int.Parse(result.ToString());
    }
}