using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemScriptableObject", menuName = "ScriptableObjects/GameSaveDataItemScriptableObject", order = 1)]
public class ItemScriptableObject : ScriptableObject {
    public GameControlTypeManager.ItemType itemType;
    public GameControlTypeManager.InvestigateResultType investigateResultType;
    public GameControlSerializableDictionary.ItemLabelTextDictionary itemLabelTextDictionary;
}