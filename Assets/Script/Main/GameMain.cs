using ECSCommons;
using System.Collections;
using UnityEngine;

/// <summary> 各システムを実行するクラス </summary>
public class GameMain : MonoBehaviour
{
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
        if (!gameObject.TryGetComponent(out GameMainUpdate _)) { _updateSystem = gameObject.AddComponent<GameMainUpdate>(); }

        _updateSystem.enabled = false;
    }

    private IEnumerator Start()
    {
        Initialize();
        SetupMasterSystem();

        yield return Fade.Instance.FadeIn();

        Loaded();
    }

    private void Initialize()
    {
        foreach (var entity in _gameState.Entities)
        {
            entity.SetUp();
            foreach (var component in entity.Components) { SetupComponents(component); }
        }
    }

    private void SetupMasterSystem()
    {
        _gameMain.SetupMasterSystem(ref _masterSystem, _gameState);
        _masterSystem.Initialize();
    }

    /// <summary> 各Componentのセットアップ </summary>
    private void SetupComponents(IComponent component) { }

    /// <summary> データの初期設定が全て終了したときに実行する </summary>
    private void Loaded()
    {
        //設定したステータスを割り当て、update処理を開始する
        _updateSystem.MasterSystem = _masterSystem;
        _updateSystem.enabled = true;
    }

    private void OnDestroy() => _masterSystem.OnDestroy();
}