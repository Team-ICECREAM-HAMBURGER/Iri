using UnityEngine;
using UnityEngine.Serialization;

public class Item : MonoBehaviour {
    [SerializeField] private GameControlSerializableDictionary.ItemLabelObjectDictionary itemLabelObjectDictionary;
    
    private ItemTossController itemTossController;
    private GameControlTypeManager.ItemType itemType;
    private GameControlTypeManager.InvestigateResultType investigateResultType;
    private GameControlSerializableDictionary.ItemLabelTextDictionary itemLabelTextDictionary;

    private string itemOwnerName;
    private Vector2 itemInitPosition;


    private void Init() {
        this.itemTossController = this.GetComponent<ItemTossController>();
        this.itemTossController.onItemToss.AddListener(OnItemReturn);
        
        this.itemInitPosition = this.gameObject.transform.localPosition;
    }
    
    private void Awake() {
        Init();
    }
    
    public void Init(PassengerData data, GameControlTypeManager.ItemType itemType) {
        this.gameObject.transform.localPosition = this.itemInitPosition;    // 아이템 위치 초기화
        
        // 아이템 정보 등록 //
        this.itemLabelTextDictionary = new();
        
        this.itemType = itemType;
        this.investigateResultType 
            = data.possessionItemScriptableObjectDictionary[this.itemType].investigateResultType;
        this.itemLabelTextDictionary 
            = data.possessionItemScriptableObjectDictionary[this.itemType].itemLabelTextDictionary;
        
        foreach (var label in this.itemLabelTextDictionary) {
            this.itemLabelObjectDictionary[label.Key].text = label.Value;   // 텍스트 정보 갱신
        }

        this.itemOwnerName = this.itemLabelTextDictionary[GameControlTypeManager.ItemLabelType.NAME];
        
        // 아이템 오브젝트 ON //
        this.gameObject.SetActive(true);
    }

    private void OnItemReturn() {
        ItemInvestigateManager.Instance.PassengerItemReturnCheck(this.itemType, this.itemOwnerName);    // 아이템 제출
    }
}