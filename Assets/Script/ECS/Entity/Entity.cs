using ECSCommons;
using UnityEngine;

public class Entity
{
    public GameObject GameObject { get; set; }
    public Transform Transform { get; set; }
    public IComponent[] ComponentsHolder { get; set; }

    /// <summary> 特定のコンポーネントをEntityから取得する </summary>
    public static T GetComponent<T>() where T : IComponent
    {
        var hash = ECSConsts.GetComponentHash<T>();

        return (T)ECSConsts.ComponentsHolder[hash];
    }

    /// <summary> 特定のコンポーネントこのEntityが取得できたかどうか </summary>
    public static bool TryGetComponent<T>(out T target) where T : IComponent
    {
        foreach (var component in ECSConsts.ComponentsHolder.Values)
        {
            if (component is T)
            {
                target = (T)component;
                return true;
            }
        }
        target = default;
        return false;
    }
}