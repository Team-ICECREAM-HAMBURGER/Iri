using UnityEngine;

[CreateAssetMenu(fileName = "GameSaveDataFamilyScriptableObject", menuName = "ScriptableObjects/GameSaveDataFamilyScriptableObject", order = 1)]
public class GameSaveDataFamilyScriptableObject : ScriptableObject {
    public string tag;
    public string familyName;
    public GameControlTypeManager.FamilyType familyType;
    public GameControlTypeManager.FamilyStatusType familyStatus;
}