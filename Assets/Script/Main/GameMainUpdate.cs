using UnityEngine;

public class GameMainUpdate : MonoBehaviour
{
    public MasterSystem MasterSystem { get; set; }

    private void Update() => MasterSystem.OnUpdate();
}