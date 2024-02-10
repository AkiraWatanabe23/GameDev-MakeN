using ECSCommons;

public class CalcDataHolderComponent : IComponent
{
    /// <summary> 計算式に含まれる数字 </summary>
    public int[] Numbers { get; set; }
    /// <summary> 計算式に含まれる計算記号 </summary>
    public CalculationSymbolType[] CalcSymbols { get; set; }
    /// <summary> 数字、計算記号を含んだ計算式 </summary>
    public string[] FromulaArray {  get; set; }

    public Entity Entity { get; set; }
}
