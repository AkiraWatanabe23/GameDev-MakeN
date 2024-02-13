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

        public Action<int> OnGetRandomNumberForSeed;
        public Action<int, int> OnGetRandomNumberForRange;

        //View
        public Action<int, float> OnNumberView;
        public Action<int> OnUpdateResultValueView;
        public Action<string> OnUpdateFormulaView;
    }
}
