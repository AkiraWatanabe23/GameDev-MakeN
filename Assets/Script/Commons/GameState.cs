using System;

namespace ECSCommons
{
    [Serializable]
    public class GameState
    {
        public ViewComponent ViewComponent { get; set; }

        public int TargetValue { get; set; }
    }
}
