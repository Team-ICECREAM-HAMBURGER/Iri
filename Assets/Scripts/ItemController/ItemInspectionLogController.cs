using TMPro;
using UnityEngine;

public class ItemInspectionLogController : ItemController {
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text gender;
    [SerializeField] private TMP_Text dob;

    [SerializeField] private TMP_Text note;


    protected override void ItemRefresh(GameControlSerializableDictionary.ItemSaveData passengerItemSaveData) {
        if (passengerItemSaveData.TryGetValue(this.itemType, out var data)) {
            this.name.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
            this.gender.text = data.informationValue[GameControlTypeManager.ItemLabelType.GENDER];
            this.dob.text = data.informationValue[GameControlTypeManager.ItemLabelType.DOB];
            this.note.text = data.informationValue[GameControlTypeManager.ItemLabelType.NOTE];

            this.gameObject.SetActive(true);
        }
    }

    private void Awake() {
        Init();
    }
}
