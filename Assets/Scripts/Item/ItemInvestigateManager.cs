using UnityEngine;

public class ItemInvestigateManager : GameControlSingleton<ItemInvestigateManager> {
    public GameControlSerializableDictionary.ItemGameObjectDictionary itemPrefabDictionary;
    [SerializeField] private Transform itemSpawnTransform;
    
    [HideInInspector] public bool isOK;
    [HideInInspector] public bool isInvestigating;
    
    private PassengerData targetPassengerData;
    private int passengerItemReturnCount;
    private int investigationItemReturnCount;
    
    
    public void PassengerItemInit(PassengerData passengerData) {
        this.passengerItemReturnCount = 0;
        this.targetPassengerData = passengerData;
        
        foreach (var itemType in passengerData.possessionItems) {
            var itemObj = Instantiate(this.itemPrefabDictionary[itemType], this.itemSpawnTransform);
            var itemScp = itemObj.GetComponent<Item>();
            
            itemScp.Init(passengerData, itemType);
        }
    }

    public void InvestigationItemInit(PassengerData passengerData) {
        this.investigationItemReturnCount = 0;
        this.targetPassengerData = passengerData;

        var inspectionLogObj = Instantiate(
            this.itemPrefabDictionary[GameControlTypeManager.ItemType.INSPECTION_LOG], this.itemSpawnTransform);
        var inspectionReportObj = Instantiate(
            this.itemPrefabDictionary[GameControlTypeManager.ItemType.INSPECTION_REPORT], this.itemSpawnTransform);
        var inspectionLogScp = inspectionLogObj.GetComponent<ItemInvestigationLogBehaviour>();
        var inspectionReportScp = inspectionReportObj.GetComponent<ItemInvestigationReportBehaviour>();
        
        inspectionLogScp.Init(passengerData);
        inspectionReportScp.Init(passengerData);
    }

    public void PassengerItemReturnCheck(GameControlTypeManager.ItemType itemType) {
        // 반납 아이템 카운트 //
        if (this.targetPassengerData.possessionItems.Contains(itemType)) {
            this.passengerItemReturnCount++;
        }
    }

    public void InvestigationItemReturnCheck(GameControlTypeManager.ItemType itemType) {
        if (itemType == GameControlTypeManager.ItemType.INSPECTION_LOG ||
            itemType == GameControlTypeManager.ItemType.INSPECTION_REPORT) {
            this.investigationItemReturnCount++;
        }
    }

    public GameControlTypeManager.InvestigateResultType InvestigationResult() {
        GameControlTypeManager.InvestigateResultType result = GameControlTypeManager.InvestigateResultType.이상없음;
        
        // 반납 물품 누락 검증 //
        if (this.passengerItemReturnCount < this.targetPassengerData.possessionItems.Count) {
            result = GameControlTypeManager.InvestigateResultType.물품반납누락;
        }
        
        // 반납 서류 누락 검증 //
        if (this.investigationItemReturnCount < 2) {
            result = GameControlTypeManager.InvestigateResultType.필수서류누락;
        }
        
        // 아이템 검증 //
        if (this.isOK &&
            this.targetPassengerData.investigateResult != GameControlTypeManager.InvestigateResultType.이상없음) {
            result = this.targetPassengerData.investigateResult;
        }
        else if (!this.isOK &&
                 this.targetPassengerData.investigateResult == GameControlTypeManager.InvestigateResultType.이상없음) {
            result = GameControlTypeManager.InvestigateResultType.검역오류;
        }

        return result;
    }
}