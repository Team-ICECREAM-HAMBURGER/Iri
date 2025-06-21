using UnityEngine;

[CreateAssetMenu(fileName = "GameSaveDataItemScriptableObject", menuName = "ScriptableObjects/GameSaveDataItemScriptableObject", order = 1)]
public class ItemScriptableObject : ScriptableObject {
    public GameControlTypeManager.ItemType itemType;
    
    [Space(10f)]
    
    public GameControlSerializableDictionary.ItemLabel informationValue;
}