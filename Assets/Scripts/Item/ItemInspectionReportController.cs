using UnityEngine;

public class ItemInspectionReportController : ItemController {
    [SerializeField] private MobileConsoleStampController mobileConsoleStampController;
    
    
    protected override void ItemRefresh(
        (GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData) {
        if (passengerItemSaveData.Item2.ContainsKey(this.itemType)) {
            this.mobileConsoleStampController.OnPaperStampReset.Invoke();
            
            this.itemRefreshTransform.anchoredPosition = this.itemRefreshPosition;
            this.gameObject.SetActive(true);
        }
    }
    
    private void Awake() {
        Init();
    }
}