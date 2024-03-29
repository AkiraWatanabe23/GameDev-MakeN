﻿using System.Collections.Generic;
using UnityEngine;

namespace Constants
{
    /// <summary> 定数管理ファイル </summary>
    public static class Consts
    {
        /// <summary> SEの同時再生上限 </summary>
        public const int SEPlayableLimit = 5;

        /// <summary> enumとシーン名のDictionary </summary>
        public static readonly Dictionary<SceneName, string> Scenes = new()
        {
            { SceneName.Title, "TitleScene" },
            { SceneName.Home, "HomeScene" },
            { SceneName.InGameSolo, "SoloModeGameScene" },
            { SceneName.InGameClient, "ClientGameScene" },
            { SceneName.InGameServer, "ServerGameScene" }
        };

        /// <summary> 指定したシーンのシーン名を取得する </summary>
        public static string GetSceneNameString(SceneName scene) => Scenes[scene];
    }

    /// <summary> Console Logs </summary>
    public static class EditorLog
    {
        public static void Message(object message)
        {
#if UNITY_EDITOR
            Debug.Log(message);
#endif
        }

        public static void Warning(object message)
        {
#if UNITY_EDITOR
            Debug.LogWarning(message);
#endif
        }

        public static void Error(object message)
        {
#if UNITY_EDITOR
            Debug.LogError(message);
#endif
        }
    }
}

public enum SceneName
{
    Title,
    Home,
    InGameSolo,
    InGameClient,
    InGameServer,
}
