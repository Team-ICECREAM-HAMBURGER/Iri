using System.Collections.Generic;


public struct PassengerData {
    public string name;
    public string dob;
    public string gender;
    public string investigateNote;
    public GameControlTypeManager.VehicleTrainType passengerTrainType;
    public GameControlTypeManager.InvestigateResultType investigateResult;
    public List<GameControlTypeManager.ItemType> possessionItems;
    public GameControlSerializableDictionary.ItemScriptableObjectDictionary possessionItemScriptableObject;
}

public class Passenger {
    private readonly PassengerData passengerData;

    public Passenger(PassengerScriptableObject data) {
        this.passengerData = new();
        this.passengerData.possessionItems = new();
        
        this.passengerData.name = data.name;
        this.passengerData.dob = data.dob;
        this.passengerData.gender = data.gender;
        this.passengerData.passengerTrainType = data.passengerTrainType;
        this.passengerData.investigateNote = data.investigateNote;
        this.passengerData.investigateResult = data.investigateResult;

        var values = data.possessionItemScriptableObject.Values;
        foreach (var value in values) {
            this.passengerData.possessionItems.Add(value.itemType);
        }
        
        this.passengerData.possessionItemScriptableObject = data.possessionItemScriptableObject;
    }

    public void PassengerItemInit() {
        ItemInvestigateManager.Instance.PassengerItemInit(this.passengerData);
        ItemInvestigateManager.Instance.InvestigationItemInit(this.passengerData);
    }
}