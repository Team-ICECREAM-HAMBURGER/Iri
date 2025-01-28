using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemBookController : ItemController {
    [SerializeField] private TMP_Text title;


    protected override void ItemRefresh(GameControlSerializableDictionary.ItemSaveData passengerItemSaveData) {
        if (passengerItemSaveData.TryGetValue(this.itemType, out var data)) {
            this.title.text = data.informationValue[GameControlTypeManager.ItemLabelType.TITLE];
            
            this.gameObject.SetActive(true);
        }
    }

    private void Awake() {
        Init();
    }
}