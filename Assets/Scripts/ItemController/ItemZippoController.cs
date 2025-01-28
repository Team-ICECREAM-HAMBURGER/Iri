using TMPro;
using UnityEngine;

public class ItemZippoController : ItemController {
    [SerializeField] private TMP_Text passcode;


    protected override void ItemRefresh(GameControlSerializableDictionary.ItemSaveData passengerItemSaveData) {
        this.gameObject.SetActive(true);
    }

    private void Awake() {
        Init();
    }
}
