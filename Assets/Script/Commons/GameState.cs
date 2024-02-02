using System;
using UnityEngine;

namespace ECSCommons
{
    [Serializable]
    public class GameState
    {
        [field: SerializeField]
        public Turn CurrentTurn { get; set; } = Turn.None;
        [field: SerializeField]
        public int TargetMinValue { get; private set; } = 0;
        [field: SerializeField]
        public int TargetMaxValue { get; private set; } = 0;

        public ViewComponent ViewComponent { get; set; }

        public int TargetValue { get; set; } = 0;
        public Turn SelfTurn { get; set; } = Turn.None;
    }
}
