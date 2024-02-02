using ECSCommons;
using UnityEngine;

public class RandomNumberSystem : SystemBase
{
    public override void SetupEvent()
    {
        GameEvent.OnGetRandomNumberForSeed += GetRandomNumber;
        GameEvent.OnGetRandomNumberForRange += GetRandomNumber;
    }

    public override void OnDestroy()
    {
        GameEvent.OnGetRandomNumberForSeed -= GetRandomNumber;
        GameEvent.OnGetRandomNumberForRange -= GetRandomNumber;
    }

    /// <summary> ランダムな値を生成する（シード値設定） </summary>
    /// <param name="seedValue"> シード値 </param>
    private void GetRandomNumber(int seedValue)
    {
        //シード値を設定する
        Random.InitState(seedValue);
        // Random.value ... 0f ～ 1f のランダム値を取得
        GameState.TargetValue = (int)Random.value;
    }

    /// <summary> ランダムな値を生成する（範囲設定） </summary>
    private void GetRandomNumber()
        => GameState.TargetValue = Random.Range(GameState.TargetMinValue, GameState.TargetMaxValue + 1);
}
