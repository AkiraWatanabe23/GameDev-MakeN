using ECSCommons;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 実際にシーン上に存在するオブジェクトに付けるComponent </summary>
public class EntityComponent : MonoBehaviour
{
    [Tooltip("このEntityがもつデータ群")]
    [SubclassSelector]
    [SerializeReference]
    [SerializeField]
    private List<IComponent> _components = new();

    public List<IComponent> Components => _components;
    public Entity Entity { get; private set; }

    public void SetUp()
    {
        if (Entity != null) { return; }

        Entity = new()
        {
            GameObject = gameObject,
            Transform = transform,
            ComponentsHolder = _components.ToArray()
        };
    }
}