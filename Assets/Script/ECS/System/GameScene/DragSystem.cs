using UnityEngine;

public class DragSystem : SystemBase
{
    private RectTransform _dragTarget = default;

    public override void Initialize()
    {
        if (GameState.Receivers != null && GameState.Receivers.Length > 0)
        {
            foreach (var receiver in GameState.Receivers) { receiver.Init(GameEvent); }
        }
    }

    public override void SetupEvent()
    {
        GameEvent.OnDragBegin += DragBegin;
        GameEvent.OnDrag += Drag;
        GameEvent.OnDragEnd += DragEnd;
    }

    public override void OnDestroy()
    {
        GameEvent.OnDragBegin -= DragBegin;
        GameEvent.OnDrag -= Drag;
        GameEvent.OnDragEnd -= DragEnd;
    }

    private void DragBegin(RectTransform target) => _dragTarget = target;

    private void Drag(Vector2 updatePos)
    {
        if (_dragTarget == null) { return; }

        _dragTarget.position = updatePos;
    }

    private void DragEnd()
    {
        if (_dragTarget == null) { return; }

        //移動対象を解除
        _dragTarget = null;
    }
}
