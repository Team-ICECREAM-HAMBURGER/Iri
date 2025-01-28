using TMPro;
using UnityEngine;

public class ItemAsylumGrantController : ItemController {
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text height;
    [SerializeField] private TMP_Text weight;
    [SerializeField] private TMP_Text approvalNumber;
    [SerializeField] private TMP_Text dob;


    protected override void ItemRefresh(GameControlSerializableDictionary.ItemSaveData passengerItemSaveData) {
        if (passengerItemSaveData.TryGetValue(this.itemType, out var data)) {
            this.name.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
            this.height.text = data.informationValue[GameControlTypeManager.ItemLabelType.HEIGHT];
            this.weight.text = data.informationValue[GameControlTypeManager.ItemLabelType.WEIGHT];
            this.approvalNumber.text = data.informationValue[GameControlTypeManager.ItemLabelType.APPROVAL_NUMBER];
            this.dob.text = data.informationValue[GameControlTypeManager.ItemLabelType.DOB];
            
            this.gameObject.SetActive(true);
        }
    }

    private void Awake() {
        Init();
    }
}