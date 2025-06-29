public class Passenger {
    public class PassengerData {
        public string name;
        public string dob;
        public string gender;
        public string personalNote;
    }

    private readonly GameControlSerializableDictionary.ItemScriptableObjectDictionary itemScriptableObjectDictionary;
    private readonly PassengerData passengerData;
    

    public Passenger(PassengerScriptableObject data) {
        this.passengerData = new();
        
        this.passengerData.name = data.name;
        this.passengerData.dob = data.dob;
        this.passengerData.gender = data.gender;
        this.passengerData.personalNote = data.personalNote;
        
        this.itemScriptableObjectDictionary = data.itemScriptableObjectDictionary;
    }

    public void PassengerItemInit() {
        ItemManager.Instance.PassengerItemInit(this.itemScriptableObjectDictionary);
        ItemManager.Instance.InspectionItemInit(this.passengerData);
    }
}