using TMPro;
using UnityEngine;

public class ItemIdCardNormal : Item {
    [SerializeField] private new TMP_Text name;
    [SerializeField] private TMP_Text dob;
    [SerializeField] private TMP_Text address;


    // protected override void ItemPropertyInit((GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData) {
    //     if (passengerItemSaveData.Item2.TryGetValue(this.itemType, out var data)) {
    //         this.name.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
    //         this.dob.text = data.informationValue[GameControlTypeManager.ItemLabelType.DOB];
    //         this.address.text = data.informationValue[GameControlTypeManager.ItemLabelType.ADDRESS];
    //
    //         this.itemRefreshTransform.anchoredPosition = this.itemRefreshPosition;
    //         this.gameObject.SetActive(true);
    //     }
    // }
    
    private void Awake() {
        Init();
    }

    protected override void ItemDataInit() {
        throw new System.NotImplementedException();
    }
}