using System;
using System.Collections.Generic;

namespace ECSCommons
{
    /// <summary> ECSに関連する定数ファイル </summary>
    public class ECSConsts
    {
        private static readonly Dictionary<Type, int> _hashCodes = new();
        //シーン上に存在するIComponentのデータ群
        public static Dictionary<int, IComponent> ComponentsHolder = new();

        /// <summary> コンポーネントのハッシュ値を取得する </summary>
        public static int GetComponentHash<T>() where T : IComponent
        {
            var type = typeof(T);
            var hash = type.GetHashCode();
            if (!_hashCodes.ContainsKey(type))
            {
                _hashCodes.Add(type, hash);
            }

            return hash;
        }

        /// <summary> コンポーネントを追加する </summary>
        public static void Add(IComponent component)
        {
            var id = _hashCodes[(Type)component];

            if (!ComponentsHolder.ContainsKey(id)) { ComponentsHolder.Add(id, component); }
        }
    }
}