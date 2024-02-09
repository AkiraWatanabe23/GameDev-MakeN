using ECSCommons;

public class CalcDataHolderComponent : IComponent
{
    public int[] Numbers { get; set; }
    public CalculationSymbolType[] CalcSymbols { get; set; }

    public Entity Entity { get; set; }
}
