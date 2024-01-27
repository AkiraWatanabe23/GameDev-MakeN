using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/Create CardDataAsset")]
public class CardData : ScriptableObject
{
    [field: SerializeField]
    public Sprite Sprite { get; private set; }
    [field: SerializeField]
    public CardType CardType { get; private set; }
}

public enum CardType
{
    None,
}
