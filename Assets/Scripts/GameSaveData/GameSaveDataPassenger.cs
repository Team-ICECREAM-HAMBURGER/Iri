public class GameSaveDataPassenger {
    public float randomSelectWeight;
    
    public string name;
    public string dob;
    public string gender;
    public string note;
    
    public GameControlSerializableDictionary.ItemSaveDataScriptableObject itemSaveDataScriptableObject;
    public GameControlTypeManager.VehicleTrainType vehicleTrainType;
    public GameControlTypeManager.PassengerType passengerType;

    
    public GameSaveDataPassenger(float randomSelectWeight, 
        string name, string dob, string gender, string note, 
        GameControlSerializableDictionary.ItemSaveDataScriptableObject itemSaveDataScriptableObject, 
        GameControlTypeManager.VehicleTrainType vehicleTrainType, 
        GameControlTypeManager.PassengerType passengerType) {
        this.randomSelectWeight = randomSelectWeight;
       
        this.name = name;
        this.dob = dob;
        this.gender = gender;
        this.note = note;
        
        this.itemSaveDataScriptableObject = itemSaveDataScriptableObject;
        this.vehicleTrainType = vehicleTrainType;
        this.passengerType = passengerType;
    }

    public GameSaveDataPassenger(GameSaveDataPassengerScriptableObject data) {
        this.randomSelectWeight = data.randomSelectWeight;
        
        this.name = data.name;
        this.dob = data.dob;
        this.gender = data.gender;
        this.note = data.note;
        
        this.itemSaveDataScriptableObject = data.itemSaveDataScriptableObject;
        this.vehicleTrainType = data.vehicleTrainType;
        this.passengerType = data.passengerType;
    }
}