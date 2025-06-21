using UnityEngine;

public abstract class Item : MonoBehaviour {
    public GameControlTypeManager.ItemType itemType;
    public RectTransform itemRefreshTransform;
    
    protected Vector2 itemRefreshPosition;
    
    
    public void Init() {
        this.itemRefreshPosition = this.itemRefreshTransform.anchoredPosition;
        
        this.gameObject.SetActive(false);
    }

    protected abstract void ItemDataInit();
}