using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemAsylumGrantController : ItemController {
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text height;
    [SerializeField] private TMP_Text weight;
    [SerializeField] private TMP_Text approvalNumber;
    [SerializeField] private TMP_Text dob;


    protected override void ItemRefresh((GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData) {
        if (passengerItemSaveData.Item2.TryGetValue(this.itemType, out var data)) {
            this.itemName.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
            this.height.text = data.informationValue[GameControlTypeManager.ItemLabelType.HEIGHT];
            this.weight.text = data.informationValue[GameControlTypeManager.ItemLabelType.WEIGHT];
            this.approvalNumber.text = data.informationValue[GameControlTypeManager.ItemLabelType.APPROVAL_NUMBER];
            this.dob.text = data.informationValue[GameControlTypeManager.ItemLabelType.DOB];
            
            this.itemRefreshTransform.anchoredPosition = this.itemRefreshPosition;
            this.gameObject.SetActive(true);
        }
    }

    private void Awake() {
        Init();
    }
}