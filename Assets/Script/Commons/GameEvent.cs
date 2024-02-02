using System;

namespace ECSCommons
{
    [Serializable]
    public class GameEvent
    {
        public Action OnPause;
        public Action OnResume;

        public Action<Turn> OnTurnChange;

        //View
        public Action<int, float> OnNumberView;

        /// <summary> 最小値、最大値の幅から選ぶ </summary>
        public Action OnGetRandomNumberForRange;
        /// <summary> シード値を設定する </summary>
        public Action<int> OnGetRandomNumberForSeed;
    }
}
