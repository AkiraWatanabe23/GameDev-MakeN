using System;
using UnityEngine;

namespace ECSCommons
{
    [Serializable]
    public class GameState
    {
        [field: SerializeField]
        public Turn CurrentTurn { get; set; } = Turn.None;

        [Tooltip("何個の数字で行うか")]
        [Range(2, 10)]
        [SerializeField]
        private int _numbersCount = 2;

        public int NumbersCount => _numbersCount;

        public CalcDataHolderComponent Player { get; set; }
        public ViewComponent ViewComponent { get; set; }
        public Turn SelfTurn { get; set; } = Turn.None;

        public const int TargetValue = 21;
    }
}
