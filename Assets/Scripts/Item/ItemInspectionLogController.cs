using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemInspectionLogController : ItemController {
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text gender;
    [SerializeField] private TMP_Text dob;

    [SerializeField] private TMP_Text note;


    protected override void ItemRefresh((GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData) {
        if (passengerItemSaveData.Item2.ContainsKey(this.itemType)) {
            this.itemName.text = passengerItemSaveData.Item1.name;
            this.gender.text = passengerItemSaveData.Item1.gender;
            this.dob.text = passengerItemSaveData.Item1.dob;
            this.note.text = passengerItemSaveData.Item1.note;

            this.itemRefreshTransform.anchoredPosition = this.itemRefreshPosition;
            this.gameObject.SetActive(true);
        }
    }

    private void Awake() {
        Init();
    }
}
