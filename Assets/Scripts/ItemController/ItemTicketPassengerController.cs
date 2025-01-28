using TMPro;
using UnityEngine;

public class ItemTicketPassengerController : ItemController {
    [SerializeField] private TMP_Text division;
    [SerializeField] private TMP_Text ticketType;
    [SerializeField] private TMP_Text IssueDate;


    protected override void ItemRefresh(GameControlSerializableDictionary.ItemSaveData passengerItemSaveData) {
        if (passengerItemSaveData.TryGetValue(this.itemType, out var data)) {
            this.division.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
            this.ticketType.text = data.informationValue[GameControlTypeManager.ItemLabelType.TITLE];
            this.IssueDate.text = data.informationValue[GameControlTypeManager.ItemLabelType.DATE];

            this.gameObject.SetActive(true);
        }
    }

    private void Awake() {
        Init();
    }
}