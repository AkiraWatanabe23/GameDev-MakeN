using ECSCommons;
using UnityEngine;
using UnityEngine.UI;

public class ViewComponent : IComponent
{
    [SerializeField]
    private Text _targetNumberText = default;

    public Text TargetNumberText => _targetNumberText;

    public Entity Entity { get; set; }
}
