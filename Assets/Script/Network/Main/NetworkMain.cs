using Constants;
using Network;
using System.Threading.Tasks;
using UnityEngine;

public class NetworkMain : MonoBehaviour
{
    private NetworkMastersystem _masterSystem = default;
    private NetworkMainUpdate _updateSystem = default;

    private NetworkClient _client = default;
    
    private void Awake()
    {
        _updateSystem = gameObject.TryGetComponent(out NetworkMainUpdate update) ? update : gameObject.AddComponent<NetworkMainUpdate>();

        _updateSystem.enabled = false;
    }

    private async void Start()
    {
        SetupMasterSystem();
        Loaded();

        await ConnectionStart();
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

    private async Task ConnectionStart()
    {
        await Task.Yield();
    }

    private void OnDestroy() => _masterSystem?.OnDestroy();
}
