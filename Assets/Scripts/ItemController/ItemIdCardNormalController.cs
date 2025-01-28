using TMPro;
using UnityEngine;

public class ItemIdCardNormalController : ItemController {
    [SerializeField] private new TMP_Text name;
    [SerializeField] private TMP_Text dob;
    [SerializeField] private TMP_Text address;


    protected override void ItemRefresh(GameControlSerializableDictionary.ItemSaveData passengerItemSaveData) {
        if (passengerItemSaveData.TryGetValue(this.itemType, out var data)) {
            this.name.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
            this.dob.text = data.informationValue[GameControlTypeManager.ItemLabelType.DOB];
            this.address.text = data.informationValue[GameControlTypeManager.ItemLabelType.ADDRESS];

            this.gameObject.SetActive(true);
        }
    }
    
    private void Awake() {
        Init();
    }
}