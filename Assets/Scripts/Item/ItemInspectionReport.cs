using UnityEngine;

public class ItemInspectionReport : Item {
    [SerializeField] private MobileConsoleStampController mobileConsoleStampController;
    
    
    // protected override void ItemPropertyInit(
    //     (GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData) {
    //     if (passengerItemSaveData.Item2.ContainsKey(this.itemType)) {
    //         this.mobileConsoleStampController.OnPaperStampReset.Invoke();
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