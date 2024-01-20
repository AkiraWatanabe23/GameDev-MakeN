using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSystem : SystemBase
{
    public override void SetupEvent()
    {
        GameEvent.OnNumberView += NumberView;
    }

    public override void OnDestroy()
    {
        GameEvent.OnNumberView -= NumberView;
    }

    private void NumberView(int value) => GameState.ViewComponent.TargetNumberText.text = value.ToString();
}
