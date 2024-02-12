using System;
using UnityEngine;

namespace ECSCommons
{
    [Serializable]
    public class GameEvent
    {
        public Action OnPause;
        public Action OnResume;

        public Action OnTurnStart;
        public Action OnTurnEnd;

        public Action OnApplyFormula;

        //View
        public Action<int, float> OnNumberView;

        //Input
        public Action<RectTransform> OnDragBegin;
        public Action<Vector2> OnDrag;
        public Action OnDragEnd;
    }
}
