using System.Collections.Generic;
using UnityEngine;

public class ItemInvestigateManager : GameControlSingleton<ItemInvestigateManager> {
    public GameControlSerializableDictionary.ItemGameObjectDictionary itemPrefabDictionary;
    
    [HideInInspector] public bool isStampOK;
    
    [SerializeField] private Transform itemSpawnTransform;
    
    private int passengerItemReturnCount;
    private int investigationItemReturnCount;
    private PassengerData targetPassengerData;
    

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
        PlayerBehaviour.Instance.isInvestigating = true;
        PlayerBehaviour.Instance.currentInvestigatingTrainType = passengerData.passengerTrainType;
        
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
        if (this.targetPassengerData.possessionItems.Contains(itemType)) {
            this.passengerItemReturnCount++;
        }
    }

    public void InvestigationItemReturnCheck(GameControlTypeManager.ItemType itemType) {
        if (itemType == GameControlTypeManager.ItemType.INSPECTION_LOG ||
            itemType == GameControlTypeManager.ItemType.INSPECTION_REPORT) {
            this.investigationItemReturnCount++;
        }

        if (this.investigationItemReturnCount >= 2) {
            PlayerBehaviour.Instance.isInvestigating = false;
        }
    }

    public GameControlTypeManager.InvestigateResultType InvestigationResult() {
        GameControlTypeManager.InvestigateResultType result = GameControlTypeManager.InvestigateResultType.이상없음;
        
        // 반납 물품 누락 검증 //
        if (this.passengerItemReturnCount < this.targetPassengerData.possessionItems.Count) {
            result = GameControlTypeManager.InvestigateResultType.물품반납누락;
        }
        
        // 아이템 검증 //
        if (this.isStampOK &&
            this.targetPassengerData.investigateResult != GameControlTypeManager.InvestigateResultType.이상없음) {
            result = this.targetPassengerData.investigateResult;
        }
        else if (!this.isStampOK &&
                 this.targetPassengerData.investigateResult == GameControlTypeManager.InvestigateResultType.이상없음) {
            result = GameControlTypeManager.InvestigateResultType.검역오류;
        }
        
        return result;
    }
}