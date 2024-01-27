using Network;
using UnityEngine;

public class NetworkMainUpdate : MonoBehaviour
{
    private NetworkMastersystem _masterSystem = default;

    public void SetupMasterSystem(NetworkMastersystem masterSystem) => _masterSystem = masterSystem;

    private void Update() => _masterSystem.OnUpdate();
}
