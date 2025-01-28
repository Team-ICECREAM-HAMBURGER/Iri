public class GameSaveDataItem {
    public GameControlTypeManager.ItemType itemType;
    
    public GameControlSerializableDictionary.ItemLabel informationValue;


    public GameSaveDataItem(GameControlTypeManager.ItemType itemType, 
        GameControlSerializableDictionary.ItemLabel informationValue) {
        this.itemType = itemType;
        this.informationValue = informationValue;
    }

    public GameSaveDataItem(GameSaveDataItemScriptableObject data) {
        this.itemType = data.itemType;
        this.informationValue = data.informationValue;
    }
}