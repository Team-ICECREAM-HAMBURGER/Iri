public class Passenger {
    public string name;
    public string dob;
    public string gender;
    
    public GameControlSerializableDictionary.ItemScriptableObjectDictionary itemScriptableObjectDictionary;
    

    public Passenger(PassengerScriptableObject data) {
        this.name = data.name;
        this.dob = data.dob;
        this.gender = data.gender;
        this.itemScriptableObjectDictionary = data.itemScriptableObjectDictionary;
    }

    public void PassengerItemInit() {
        ItemManager.Instance.PassengerItemInit(this.itemScriptableObjectDictionary);
    }
}