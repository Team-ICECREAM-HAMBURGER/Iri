using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemEntryPermitController : ItemController {
    [SerializeField] private TMP_Text purpose;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text dob;
    [SerializeField] private TMP_Text expireDate;


    protected override void ItemRefresh(
        (GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData) {
        if (passengerItemSaveData.Item2.TryGetValue(this.itemType, out var data)) {
            this.purpose.text = data.informationValue[GameControlTypeManager.ItemLabelType.PURPOSE];
            this.itemName.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
            this.dob.text = data.informationValue[GameControlTypeManager.ItemLabelType.DOB];
            this.expireDate.text = data.informationValue[GameControlTypeManager.ItemLabelType.DATE];
            
            this.itemRefreshTransform.anchoredPosition = this.itemRefreshPosition;
            this.gameObject.SetActive(true);
        }
    }
    
    private void Awake() {
        Init();
    }
}