using System;
using UnityEngine;

namespace ECSCommons
{
    [Serializable]
    public class GameState
    {
        [field: SerializeField]
        public float TimeLimit { get; set; }

        [Tooltip("何個の数字で行うか")]
        [Range(2, 10)]
        [SerializeField]
        private int _numbersCount = 2;
        [field: SerializeField]
        private EntityComponent[] _calcButtons = default;

        private CalcButtonComponent[] _buttons = default;

        public int NumbersCount => _numbersCount;
        public CalcButtonComponent[] CalcButtons
        {
            get
            {
                if (_buttons == null)
                {
                    _buttons = new CalcButtonComponent[_calcButtons.Length];
                    for (int i = 0; i < _buttons.Length; i++)
                    {
                        _buttons[i] = _calcButtons[i].Entity.GetComponent<CalcButtonComponent>();
                    }
                }

                return _buttons;
            }
        }

        public CalcDataHolderComponent Player { get; set; }
        public ViewComponent ViewComponent { get; set; }

        public int TargetValue { get; set; }
    }
}
