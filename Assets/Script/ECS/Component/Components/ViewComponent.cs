using ECSCommons;
using UnityEngine;
using UnityEngine.UI;

public class ViewComponent : IComponent
{
    [field: SerializeField]
    public Text CurrentTurnText { get; private set; } = default;
    [field: SerializeField]
    public Text TargetNumberText { get; private set; } = default;

    public Entity Entity { get; set; }
}
