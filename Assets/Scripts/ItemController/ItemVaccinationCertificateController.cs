using TMPro;
using UnityEngine;

public class ItemVaccinationCertificateController : ItemController {
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text vaccinateDate;
    [SerializeField] private TMP_Text dob;


    protected override void ItemRefresh(GameControlSerializableDictionary.ItemSaveData passengerItemSaveData) {
        if (passengerItemSaveData.TryGetValue(this.itemType, out var data)) {
            this.name.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
            this.vaccinateDate.text = data.informationValue[GameControlTypeManager.ItemLabelType.DATE];
            this.dob.text = data.informationValue[GameControlTypeManager.ItemLabelType.DOB];

            this.gameObject.SetActive(true);
        }
    }

    private void Awake() {
        Init();
    }
}