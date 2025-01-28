using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemEntryPermitController : ItemController {
    [SerializeField] private TMP_Text purpose;
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text dob;
    [SerializeField] private TMP_Text expireDate;


    protected override void ItemRefresh(GameControlSerializableDictionary.ItemSaveData passengerItemSaveData) {
        if (passengerItemSaveData.TryGetValue(this.itemType, out var data)) {
            this.purpose.text = data.informationValue[GameControlTypeManager.ItemLabelType.PURPOSE];
            this.name.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
            this.dob.text = data.informationValue[GameControlTypeManager.ItemLabelType.DOB];
            this.expireDate.text = data.informationValue[GameControlTypeManager.ItemLabelType.DATE];
            
            this.gameObject.SetActive(true);
        }
    }
    
    private void Awake() {
        Init();
    }
}