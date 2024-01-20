using ECSCommons;
using TMPro;
using UnityEngine;

public class ViewComponent : IComponent
{
    [SerializeField]
    private TMP_Text _targetNumberText = default;

    public TMP_Text TargetNumberText => _targetNumberText;

    public Entity Entity { get; set; }
}
