using TMPro;
using UnityEngine;

public class ItemTicketPassenger : Item {
    [SerializeField] private TMP_Text division;
    [SerializeField] private TMP_Text ticketType;
    [SerializeField] private TMP_Text IssueDate;


    // protected override void ItemPropertyInit((GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData) {
    //     if (passengerItemSaveData.Item2.TryGetValue(this.itemType, out var data)) {
    //         this.division.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
    //         this.ticketType.text = data.informationValue[GameControlTypeManager.ItemLabelType.TITLE];
    //         this.IssueDate.text = data.informationValue[GameControlTypeManager.ItemLabelType.DATE];
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