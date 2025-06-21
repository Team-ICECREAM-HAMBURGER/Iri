using TMPro;
using UnityEngine;

public class ItemBook : Item {
    [SerializeField] private TMP_Text title;


    // protected override void ItemPropertyInit((GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData) {
    //     if (passengerItemSaveData.Item2.TryGetValue(this.itemType, out var data)) {
    //         this.title.text = data.informationValue[GameControlTypeManager.ItemLabelType.TITLE];
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