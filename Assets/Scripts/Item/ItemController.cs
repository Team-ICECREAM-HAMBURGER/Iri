using UnityEngine;

public abstract class ItemController : MonoBehaviour {
    public GameControlTypeManager.ItemType itemType;
    public RectTransform itemRefreshTransform;
    
    protected Vector2 itemRefreshPosition;
    
    
    protected void Init() {
        this.itemRefreshPosition = this.itemRefreshTransform.anchoredPosition;
        
        this.gameObject.SetActive(false);
    }

    protected abstract void ItemRefresh((GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData) passengerItemSaveData);
}