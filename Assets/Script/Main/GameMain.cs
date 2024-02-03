using ECSCommons;
using System.Collections;
using UnityEngine;

/// <summary> 各システムを実行するクラス </summary>
public class GameMain : MonoBehaviour
{
    [SerializeField]
    private NetworkMain _networkMain = default;
    [SubclassSelector]
    [SerializeReference]
    [SerializeField]
    private IGameMain _gameMain = default;
    [SerializeField]
    private GameState _gameState = new();

    private MasterSystem _masterSystem = default;
    private GameMainUpdate _updateSystem = default;

    private void Awake()
    {
        //GameMainUpdateが無かったら割り当てる
        _updateSystem =
            gameObject.TryGetComponent(out GameMainUpdate update) ? update : gameObject.AddComponent<GameMainUpdate>();

        _updateSystem.enabled = false;
    }

    private IEnumerator Start()
    {
        yield return Initialize();
        SetupMasterSystem();

        yield return Fade.Instance.FadeIn();

        yield return ConnectionWaiting();
    }

    private IEnumerator Initialize()
    {
        var sceneEntities = FindObjectsOfType<EntityComponent>();
        yield return null;

        foreach (var entity in sceneEntities)
        {
            entity.SetUp();
            foreach (var component in entity.Components) { SetupComponents(component); }
        }
        yield return null;
    }

    /// <summary> 接続が確認されるまで待機 </summary>
    private IEnumerator ConnectionWaiting()
    {
        yield return new WaitUntil(() => _networkMain.IsConnected);

        Loaded();
    }

    private void SetupMasterSystem()
    {
        _gameMain.SetupMasterSystem(ref _masterSystem, _gameState, _networkMain);
        _masterSystem.Initialize();
    }

    /// <summary> 各Componentのセットアップ </summary>
    private void SetupComponents(IComponent component)
    {
        switch (component)
        {
            case ViewComponent:
                _gameState.ViewComponent = (ViewComponent)component; break;
        }
    }

    /// <summary> データの初期設定が全て終了したときに実行する </summary>
    private void Loaded()
    {
        //設定したステータスを割り当て、update処理を開始する
        _updateSystem.SetupMasterSystem(_masterSystem);
        _updateSystem.enabled = true;
    }

    private void OnDestroy() => _masterSystem?.OnDestroy();
}