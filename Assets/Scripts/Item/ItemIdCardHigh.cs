using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemIdCardHigh : Item {
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text divisionCode;
    [SerializeField] private TMP_Text dob;


    // protected override void ItemPropertyInit((GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData) {
    //     if (passengerItemSaveData.Item2.TryGetValue(this.itemType, out var data)) {
    //         this.itemName.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
    //         this.divisionCode.text = data.informationValue[GameControlTypeManager.ItemLabelType.CODE];
    //         this.dob.text = data.informationValue[GameControlTypeManager.ItemLabelType.DOB];
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