using ECSCommons;
using System.Collections.Generic;
using UnityEngine;

/// <summary> ���ۂɃV�[����ɑ��݂���I�u�W�F�N�g�ɕt����Component </summary>
public class EntityComponent : MonoBehaviour
{
    [Tooltip("����Entity�����f�[�^�Q")]
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