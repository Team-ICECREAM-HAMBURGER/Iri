using UnityEngine;

public class ItemManager : GameControlSingleton<ItemManager> {
    public GameControlSerializableDictionary.ItemGameObjectDictionary itemPrefabDictionary;
    
    [SerializeField] private Transform itemSpawnTransform;

    private GameControlSerializableDictionary.ItemGameObjectDictionary passengerItemDictionary;
    
    
    public void PassengerItemInit(GameControlSerializableDictionary.ItemScriptableObjectDictionary dataDictionary) {
        if (this.passengerItemDictionary != null) {
            return;
        }
        
        this.passengerItemDictionary = new();
        
        foreach (var itemData in dataDictionary) {
            var itemObj = Instantiate(this.itemPrefabDictionary[itemData.Key], this.itemSpawnTransform);
            this.passengerItemDictionary.Add(itemData.Key, itemObj);
            this.passengerItemDictionary[itemData.Key].GetComponent<Item>().Init(itemData.Value);
        }
    }

    public void InspectionItemInit(Passenger.PassengerData passengerData) {
        var inspectionLogObj 
            = Instantiate(
                this.itemPrefabDictionary[GameControlTypeManager.ItemType.INSPECTION_LOG], 
                this.itemSpawnTransform);
        var inspectionReportObj 
            = Instantiate(
                this.itemPrefabDictionary[GameControlTypeManager.ItemType.INSPECTION_REPORT],
                this.itemSpawnTransform);
        var inspectionLogScp = inspectionLogObj.GetComponent<ItemInvestigationLogBehaviour>();
        var inspectionReportScp = inspectionReportObj.GetComponent<ItemInvestigationReportBehaviour>();
        
        inspectionLogScp.Init(passengerData);
        inspectionReportScp.Init(passengerData);
    }
}