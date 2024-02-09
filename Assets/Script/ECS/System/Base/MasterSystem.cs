using ECSCommons;
using System.Collections.Generic;
using System.Net.Sockets;

/// <summary> 各Systemの管理クラス </summary>
public class MasterSystem
{
    private readonly SystemBase[] _systems = default;

    private readonly List<IUpdateSystem> _updateSystems = new();

    public GameEvent GameEvent { get; private set; }
    public GameState GameState { get; private set; }

    public NetworkStream Stream { get; private set; }

    public MasterSystem(NetworkMain networkMain, GameState gameState, params SystemBase[] systems)
    {
        GameEvent = new();
        Stream = networkMain.Network.Network.Stream;

        GameState = gameState;
        _systems = systems;

        //各Systemの初期化
        for (int i = 0; i < _systems.Length; i++)
        {
            _systems[i].MasterSystem = this;
            _systems[i].GameEvent = GameEvent;
            _systems[i].GameState = GameState;

            if (_systems[i] is IUpdateSystem) { _updateSystems.Add(_systems[i] as IUpdateSystem); }

            //ここでSystemのEvent登録
            _systems[i].SetupEvent();
        }
    }

    public void Initialize()
    {
        foreach (var system in _systems) { system.Initialize(); }
    }

    public void OnUpdate()
    {
        foreach (var system in _updateSystems) { system.OnUpdate(); }
    }

    public void OnDestroy()
    {
        foreach (var system in _systems) { system.OnDestroy(); }
    }
}