using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientViewSystem : SystemBase
{
    public override void Initialize()
    {
        GameEvent.OnGetRandomNumberForRange?.Invoke();
    }
}
