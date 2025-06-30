using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GameSaveDataItemScriptableObject", menuName = "ScriptableObjects/GameSaveDataItemScriptableObject", order = 1)]
public class ItemScriptableObject : ScriptableObject {
    public GameControlTypeManager.ItemType itemType;
    public GameControlSerializableDictionary.ItemLabelTextDictionary itemLabelTextDictionary;
}