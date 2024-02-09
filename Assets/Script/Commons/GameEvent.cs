using System;

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
    }
}
