using UnityEngine;

[CreateAssetMenu(fileName = "GameSaveDataPassengerScriptableObject", menuName = "ScriptableObjects/GameSaveDataPassengerScriptableObject", order = 1)]
public class GameSaveDataPassengerScriptableObject : ScriptableObject {
    public float randomSelectWeight;

    [Space(10f)]
    
    public new string name;
    public string dob;
    public string gender;
    public string purpose;
    [TextArea] public string note;
    
    [Space(10f)]
    
    public GameControlSerializableDictionary.ItemSaveDataScriptableObject itemSaveDataScriptableObject;
    
    [Space(10f)]
    
    public GameControlTypeManager.vehicleType vehicleType;
    public GameControlTypeManager.PassengerType passengerType;
}