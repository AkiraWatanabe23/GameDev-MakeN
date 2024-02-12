using ECSCommons;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary> プレイヤーからの入力を受けるクラス </summary>
public class InputReceive : MonoBehaviour, IPointerMoveHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform _rectTransform = default;
    private GameEvent _gameEvent = default;

    public void Init(GameEvent gameEvent)
    {
        _rectTransform = GetComponent<RectTransform>();
        _gameEvent = gameEvent;
    }

    public void OnPointerDown(PointerEventData eventData) => _gameEvent.OnDragBegin?.Invoke(_rectTransform);

    public void OnPointerMove(PointerEventData eventData) => _gameEvent.OnDrag?.Invoke(eventData.position);

    public void OnPointerUp(PointerEventData eventData) => _gameEvent.OnDragEnd?.Invoke();
}
