using Constants;
using Network;
using UnityEngine;

public class NetworkMain : MonoBehaviour
{
    private NetworkMastersystem _masterSystem = default;
    private NetworkMainUpdate _updateSystem = default;

    private void Awake()
    {
        _updateSystem = gameObject.TryGetComponent(out NetworkMainUpdate update) ? update : gameObject.AddComponent<NetworkMainUpdate>();

        _updateSystem.enabled = false;
    }

    private void Start()
    {
        SetupMasterSystem();
        Loaded();
    }

    private void SetupMasterSystem()
    {
        _masterSystem = new();
        _masterSystem.Initialize(new NetworkClient(), new NetworkServer());
    }

    private void Loaded()
    {
        EditorLog.Message("Finish NetworkSystem Initialized");

        _updateSystem.SetupMasterSystem(_masterSystem);
        _updateSystem.enabled = true;
    }

    private void OnDestroy() => _masterSystem?.OnDestroy();
}
