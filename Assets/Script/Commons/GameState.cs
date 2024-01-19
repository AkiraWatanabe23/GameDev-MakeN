using System;
using System.Collections.Generic;
using UnityEngine;

namespace ECSCommons
{
    [Serializable]
    public class GameState
    {
        [Tooltip("シーン上に存在するEntityComponent")]
        [SerializeField]
        private List<EntityComponent> _entities = default;

        public List<EntityComponent> Entities => _entities;
    }
}
