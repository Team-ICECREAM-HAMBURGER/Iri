using TMPro;
using UnityEngine;

public class ItemZippo : Item {
    [SerializeField] private TMP_Text passcode;


    // protected override void ItemPropertyInit((GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData) {
    //     if (passengerItemSaveData.Item2.TryGetValue(this.itemType, out var data)) {
    //         this.passcode.text = data.informationValue[GameControlTypeManager.ItemLabelType.CODE];
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
