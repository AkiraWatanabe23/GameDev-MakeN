using UnityEngine;

public class CalculationSystem : SystemBase
{
    private int[] _numbers = default;

    private CalculationSymbolType GetRandomCalculationSymbol()
    {
        var random = Random.Range(1, 5);
        return random switch
        {
            1 => CalculationSymbolType.Addition,
            2 => CalculationSymbolType.Subtraction,
            3 => CalculationSymbolType.Multiplication,
            4 => CalculationSymbolType.Division,
            _ => CalculationSymbolType.None
        };
    }

    private CalculationSymbolType GetCalculationSymbol(CalculationSymbolType symbol) => symbol;
}

public enum CalculationSymbolType
{
    None,
    Addition,
    Subtraction,
    Multiplication,
    Division,
}
