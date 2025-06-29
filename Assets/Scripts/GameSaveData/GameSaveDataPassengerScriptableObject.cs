using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GameSaveDataPassengerScriptableObject", menuName = "ScriptableObjects/GameSaveDataPassengerScriptableObject", order = 1)]
public class GameSaveDataPassengerScriptableObject : ScriptableObject {
    public float randomSelectWeight;

    [Space(10f)]
    
    public new string name;
    public string dob;
    public string gender;
    [TextArea] public string note;
    
    [Space(10f)]
    
    public GameControlSerializableDictionary.ItemSaveDataScriptableObject itemSaveDataScriptableObject;
    
    [FormerlySerializedAs("vehicleType")] [Space(10f)]
    
    public GameControlTypeManager.VehicleTrainType vehicleTrainType;
    public GameControlTypeManager.PassengerType passengerType;
}