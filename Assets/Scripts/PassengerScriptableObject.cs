using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassengerScriptableObject", menuName = "ScriptableObjects/GameSaveDataPassengerScriptableObject", order = 1)]
public class PassengerScriptableObject : ScriptableObject {
    public new string name;
    public string dob;
    public string gender;
    [TextArea] public string investigateNote;
    public GameControlTypeManager.VehicleTrainType passengerTrainType;
    public GameControlSerializableDictionary.ItemScriptableObjectDictionary possessionItemScriptableObject;
    
    // public List<ItemScriptableObject> possessionItemScriptableObjects;
    // public GameControlTypeManager.InvestigateResultType investigateResult;
}