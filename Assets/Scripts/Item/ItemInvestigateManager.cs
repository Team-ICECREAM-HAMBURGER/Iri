using System.Collections.Generic;
using UnityEngine;

public class ItemInvestigateManager : GameControlSingleton<ItemInvestigateManager> {
    public GameControlSerializableDictionary.ItemGameObjectDictionary itemPrefabDictionary;
    
    [HideInInspector] public bool isStampOK;
    
    [SerializeField] private Transform itemSpawnTransform;

    private HashSet<GameControlTypeManager.InvestigateResultType> targetPassengerInvestigateResultTypeSet;
    private bool hasTargetPassengerProblem;
    private int investigationItemReturnCount;
    private int targetPassengerItemReturnCount;
    private PassengerData targetPassengerData;
    private Dictionary<GameControlTypeManager.ItemType, string> targetItemOwnerInfoDictionary;    // 반납 <-> 제출 대조용
    private Dictionary<GameControlTypeManager.ItemType, GameControlTypeManager.InvestigateResultType>
        targetItemInvestigateResultTypeDictionary;
    
    public void PassengerItemInit(PassengerData passengerData) {
        this.targetItemOwnerInfoDictionary = new(); // TODO: targetPassengerData가 있는데 꼭 필요한가?
        this.targetItemInvestigateResultTypeDictionary = new();
        this.targetPassengerInvestigateResultTypeSet = new();
        this.targetPassengerItemReturnCount = 0;
        this.hasTargetPassengerProblem = false;
        this.targetPassengerData = passengerData;
        
        foreach (var item in passengerData.possessionItemScriptableObjectDictionary) {
            var itemObj = Instantiate(this.itemPrefabDictionary[item.Key], this.itemSpawnTransform);
            var itemScp = itemObj.GetComponent<Item>();
            var itemOwnerName = item.Value.itemLabelTextDictionary[GameControlTypeManager.ItemLabelType.NAME];
            
            this.targetItemOwnerInfoDictionary.Add(item.Key, itemOwnerName);  // 반납 <-> 제출 대조 딕셔너리
            this.targetItemInvestigateResultTypeDictionary.Add(item.Key, 
                passengerData.possessionItemScriptableObjectDictionary[item.Key].investigateResultType);
            
            itemScp.Init(passengerData, item.Key);  // 아이템 초기화
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

    public void PassengerItemReturnCheck(GameControlTypeManager.ItemType itemType, string itemOwnerName) {
        // if (this.targetPassengerData.possessionItems.Contains(itemType)) {
        //     this.passengerItemReturnCount++;
        // }
        
        // 아이템 위조 여부 검사 //
        if (this.targetItemOwnerInfoDictionary.TryGetValue(itemType, out var value)) { // 소지 중인가?
            // 아이템 바꿔치기 카운트 //
            if (value != itemOwnerName) {
                this.targetPassengerInvestigateResultTypeSet.Add(GameControlTypeManager.InvestigateResultType.물품반납오류);
                PlayerBehaviour.Instance.investigateWarningCount += 1;    // TODO: 함수로!
            }

            var investigateResultType = this.targetItemInvestigateResultTypeDictionary[itemType];
            
            if (investigateResultType != GameControlTypeManager.InvestigateResultType.이상없음) {    // 이상이 있는 아이템!
                this.hasTargetPassengerProblem = true;
                this.targetPassengerInvestigateResultTypeSet.Add(investigateResultType);
            }
                
            this.targetPassengerItemReturnCount++;    // 반납 카운트 +1
        }
        else { // 소지 중이 아니었던 아이템이 반납됨!
            // 아이템 끼워넣기 카운트 //
            this.targetPassengerInvestigateResultTypeSet.Add(GameControlTypeManager.InvestigateResultType.물품반납오류);
            PlayerBehaviour.Instance.investigateWarningCount += 1;
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

    public HashSet<GameControlTypeManager.InvestigateResultType> InvestigationResult() {
        // 검문 결과 판단 후 선언 //

        switch (this.isStampOK) {
            // 도장 오류 처리 //
            case true when this.hasTargetPassengerProblem: // 오류가 있는데 없다고 찍음
            case false when !this.hasTargetPassengerProblem: // 오류가 없는데 있다고 찍음
                this.targetPassengerInvestigateResultTypeSet.Add(GameControlTypeManager.InvestigateResultType.검역오류);
                break;
            default:
                this.targetPassengerInvestigateResultTypeSet.Clear();
                break;
        }
        
        // 아이템 누락 검사 //
        if (this.targetPassengerItemReturnCount != this.targetItemOwnerInfoDictionary.Count) {
            this.targetPassengerInvestigateResultTypeSet.Add(GameControlTypeManager.InvestigateResultType.물품반납누락);
        }
        
        // 아무 문제 없이 통과? //
        if (this.targetPassengerInvestigateResultTypeSet.Count == 0) {
            this.targetPassengerInvestigateResultTypeSet.Add(GameControlTypeManager.InvestigateResultType.이상없음);
        }
        
        return this.targetPassengerInvestigateResultTypeSet;
    }
}