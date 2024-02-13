using ECSCommons;
using UnityEngine;

public class Entity
{
    public GameObject GameObject { get; set; }
    public Transform Transform { get; set; }
    public IComponent[] ComponentsHolder { get; set; }

    /// <summary> 特定のコンポーネントをEntityから取得する </summary>
    public T GetComponent<T>() where T : IComponent, new()
    {
        var hash = ECSConsts.GetComponentHash<T>();

        var type = typeof(T);
        for (int i = 0; i < ComponentsHolder.Length; i++)
        {
            var getType = ComponentsHolder[i].GetType();

            if (type == getType) { return (T)ComponentsHolder[i]; }
        }

        return default;
    }

    /// <summary> 特定のコンポーネントをこのEntityから取得できたかどうか </summary>
    public bool TryGetComponent<T>(out T target) where T : IComponent
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