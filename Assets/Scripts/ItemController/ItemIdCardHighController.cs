using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemIdCardHighController : ItemController {
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text divisionCode;
    [SerializeField] private TMP_Text dob;


    protected override void ItemRefresh((GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData) {
        if (passengerItemSaveData.Item2.TryGetValue(this.itemType, out var data)) {
            this.name.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
            this.divisionCode.text = data.informationValue[GameControlTypeManager.ItemLabelType.CODE];
            this.dob.text = data.informationValue[GameControlTypeManager.ItemLabelType.DOB];
            
            this.itemRefreshTransform.anchoredPosition = this.itemRefreshPosition;
            this.gameObject.SetActive(true);
        }
    }

    private void Awake() {
        Init();
    }
}