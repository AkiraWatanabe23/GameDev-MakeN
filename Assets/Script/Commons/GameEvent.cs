using System;

namespace ECSCommons
{
    [Serializable]
    public class GameEvent
    {
        public Action OnPause;
        public Action OnResume;

        //View
        public Action<int, float> OnNumberView;

        /// <summary> 最小値、最大値を設定する </summary>
        public Action<int, int> OnGetRandomNumberForRange;
        /// <summary> シード値を設定する </summary>
        public Action<int> OnGetRandomNumberForSeed;
    }
}
