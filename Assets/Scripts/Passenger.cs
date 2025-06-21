public class Passenger {
    public float randomSelectWeight;
    
    public string name;
    public string dob;
    public string gender;
    public string note;

    public GameControlSerializableDictionary.ItemScriptableObjectDictionary itemScriptableObject;
    

    public Passenger(PassengerScriptableObject data) {
        this.name = data.name;
        this.dob = data.dob;
        this.gender = data.gender;
        this.note = data.note;
        this.itemScriptableObject = data.itemScriptableObject;
    }

    public void PassengerItemInit() {
        ItemManager.Instance.Init(this.itemScriptableObject);
    }
}