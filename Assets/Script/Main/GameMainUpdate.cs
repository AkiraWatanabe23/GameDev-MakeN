using UnityEngine;

public class GameMainUpdate : MonoBehaviour
{
    private MasterSystem _masterSystem = default;

    public void SetupMasterSystem(MasterSystem masterSystem) => _masterSystem = masterSystem;

    private void Update() => _masterSystem.OnUpdate();
}