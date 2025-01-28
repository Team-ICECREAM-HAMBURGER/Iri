using UnityEngine;

[CreateAssetMenu(fileName = "GameSaveDataItemScriptableObject", menuName = "ScriptableObjects/GameSaveDataItemScriptableObject", order = 1)]
public class GameSaveDataItemScriptableObject : ScriptableObject {
    public GameControlTypeManager.ItemType itemType;
    
    [Space(10f)]
    
    public GameControlSerializableDictionary.ItemLabel informationValue;
}