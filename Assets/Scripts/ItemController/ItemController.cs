using UnityEngine;

public abstract class ItemController : MonoBehaviour {
    public GameControlTypeManager.ItemType itemType;

    protected void Init() {
        this.gameObject.SetActive(false);
    }

    protected abstract void ItemRefresh(GameControlSerializableDictionary.ItemSaveData passengerItemSaveData);
}