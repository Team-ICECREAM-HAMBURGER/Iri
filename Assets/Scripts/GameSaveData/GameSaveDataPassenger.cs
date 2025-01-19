using System.Collections.Generic;

public class GameSaveDataPassenger {
    public readonly string tag;
    public string passengerName;
    public float weight;
    public List<GameControlTypeManager.ItemType> itemTypes;
    public GameControlTypeManager.vehicleType vehicleType;
    public GameControlTypeManager.PassengerType passengerType;

    
    public GameSaveDataPassenger(string tag, string passengerName, float weight, 
        List<GameControlTypeManager.ItemType> itemTypes,
        GameControlTypeManager.vehicleType vehicleType,
        GameControlTypeManager.PassengerType passengerType) {
        this.tag = tag;
        this.passengerName = passengerName;
        this.weight = weight;
        this.itemTypes = itemTypes;
        this.vehicleType = vehicleType;
        this.passengerType = passengerType;
    }

    public GameSaveDataPassenger(GameSaveDataPassengerScriptableObject data) {
        this.tag = data.tag;
        this.passengerName = data.passengerName;
        this.weight = data.weight;
        this.itemTypes = data.itemTypes;
        this.vehicleType = data.vehicleType;
        this.passengerType = data.passengerType;
    }
}