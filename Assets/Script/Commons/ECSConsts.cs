using Amazon.Runtime.Internal.Transform;
using System;
using System.Collections.Generic;

namespace ECSCommons
{
    /// <summary> ECSに関連する定数ファイル </summary>
    public class ECSConsts
    {
        private static readonly Dictionary<Type, int> _hashCodes = new();
        
        /// <summary> シーン上に存在するIComponentのデータ群 </summary>
        public static Dictionary<int, IComponent> ComponentsHolder = new();

        /// <summary> コンポーネントのハッシュ値を取得する </summary>
        public static int GetComponentHash<T>() where T : IComponent
        {
            var type = typeof(T);
            var hash = type.GetHashCode();
            //if (!_hashCodes.ContainsKey(type))
            //{
            //    _hashCodes.Add(type, hash);
            //    ComponentsHolder.Add(hash, (IComponent)type);
            //}

            if (!ComponentsHolder.ContainsKey(hash))
            {
                ComponentsHolder.Add(hash, (IComponent)typeof(T));
            }

            return hash;
        }
    }
}