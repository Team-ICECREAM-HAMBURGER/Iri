using TMPro;
using UnityEngine;

public class ItemVaccinationCertificateController : ItemController {
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text vaccinateDate;
    [SerializeField] private TMP_Text dob;


    protected override void ItemRefresh((GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData) {
        if (passengerItemSaveData.Item2.TryGetValue(this.itemType, out var data)) {
            this.name.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
            this.vaccinateDate.text = data.informationValue[GameControlTypeManager.ItemLabelType.DATE];
            this.dob.text = data.informationValue[GameControlTypeManager.ItemLabelType.DOB];

            this.itemRefreshTransform.anchoredPosition = this.itemRefreshPosition;
            this.gameObject.SetActive(true);
        }
    }

    private void Awake() {
        Init();
    }
}
