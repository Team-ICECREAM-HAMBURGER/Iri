public class ItemManager : GameControlSingleton<ItemManager> {
    public GameControlSerializableDictionary.ItemGameObjectDictionary itemObjectDictionary;
    
    
    public void PassengerItemInit(GameControlSerializableDictionary.ItemScriptableObjectDictionary dataDictionary) {
        foreach (var item in this.itemObjectDictionary) {
            item.Value.gameObject.SetActive(false);
        }
        
        foreach (var itemData in dataDictionary) {
            var itemObj = this.itemObjectDictionary[itemData.Key];
            var itemScp = itemObj.GetComponent<Item>();
            
            itemScp.Init(itemData.Value);
            // itemObj.SetActive(true);
        }
    }

    public void InspectionItemInit(Passenger.PassengerData passengerData) {
        var inspectionLogObj = this.itemObjectDictionary[GameControlTypeManager.ItemType.INSPECTION_LOG];
        var inspectionLogScp = inspectionLogObj.GetComponent<ItemInvestigationLogBehaviour>();
        var inspectionReportObj = this.itemObjectDictionary[GameControlTypeManager.ItemType.INSPECTION_REPORT];
        var inspectionReportScp = inspectionReportObj.GetComponent<ItemInvestigationReportBehaviour>();
        
        inspectionLogScp.Init(passengerData);
        inspectionReportScp.Init(passengerData);
    }
}