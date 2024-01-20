using System;

namespace ECSCommons
{
    [Serializable]
    public class GameEvent
    {
        public Action OnPause;
        public Action OnResume;

        public Action<int> OnNumberView;
    }
}
