using System.Collections.Generic;

public class GameSaveDataPassenger {
    public float randomSelectWeight;
    
    public string name;
    public string dob;
    public string gender;
    public string purpose;
    public string note;
    
    public GameControlSerializableDictionary.ItemSaveDataScriptableObject itemSaveDataScriptableObject;
    public GameControlTypeManager.vehicleType vehicleType;
    public GameControlTypeManager.PassengerType passengerType;

    
    public GameSaveDataPassenger(float randomSelectWeight, 
        string name, string dob, string gender, string purpose, string note, 
        GameControlSerializableDictionary.ItemSaveDataScriptableObject itemSaveDataScriptableObject, 
        GameControlTypeManager.vehicleType vehicleType, 
        GameControlTypeManager.PassengerType passengerType) {
        this.randomSelectWeight = randomSelectWeight;
       
        this.name = name;
        this.dob = dob;
        this.gender = gender;
        this.purpose = purpose;
        this.note = note;
        
        this.itemSaveDataScriptableObject = itemSaveDataScriptableObject;
        this.vehicleType = vehicleType;
        this.passengerType = passengerType;
    }

    public GameSaveDataPassenger(GameSaveDataPassengerScriptableObject data) {
        this.randomSelectWeight = data.randomSelectWeight;
        
        this.name = data.name;
        this.dob = data.dob;
        this.gender = data.gender;
        this.purpose = data.purpose;
        this.note = data.note;
        
        this.itemSaveDataScriptableObject = data.itemSaveDataScriptableObject;
        this.vehicleType = data.vehicleType;
        this.passengerType = data.passengerType;
    }
}