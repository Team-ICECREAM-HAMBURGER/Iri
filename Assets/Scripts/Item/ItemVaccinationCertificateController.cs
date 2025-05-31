using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemVaccinationCertificateController : ItemController {
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text vaccinateDate;
    [SerializeField] private TMP_Text dob;


    protected override void ItemRefresh((GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData) {
        if (passengerItemSaveData.Item2.TryGetValue(this.itemType, out var data)) {
            this.itemName.text = data.informationValue[GameControlTypeManager.ItemLabelType.NAME];
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
