using Constants;
using System.Collections.Generic;

namespace ECSCommons
{
    /// <summary> ECSに関連する定数ファイル </summary>
    public class ECSConsts
    {
        /// <summary> シーン上に存在するIComponentのデータ群 </summary>
        public static Dictionary<int, IComponent> ComponentsHolder = new();

        /// <summary> コンポーネントのハッシュ値を取得する </summary>
        public static int GetComponentHash<T>() where T : IComponent, new()
        {
            var type = typeof(T);
            var hash = type.GetHashCode();

            if (!ComponentsHolder.ContainsKey(hash))
            {
                EditorLog.Message("not key");
                ComponentsHolder.Add(hash, new T());
            }

            return hash;
        }
    }
}