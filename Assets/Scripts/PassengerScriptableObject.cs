using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GameSaveDataPassengerScriptableObject", menuName = "ScriptableObjects/GameSaveDataPassengerScriptableObject", order = 1)]
public class PassengerScriptableObject : ScriptableObject {
    public new string name;
    public string dob;
    public string gender;
    [TextArea] public string investigateNote;
    public GameControlTypeManager.VehicleTrainType passengerTrainType;
    public GameControlTypeManager.InvestigateResultType investigateResult;
    public GameControlSerializableDictionary.ItemScriptableObjectDictionary possessionItemScriptableObject;
}