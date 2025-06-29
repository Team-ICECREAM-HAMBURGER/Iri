using UnityEngine;

public class Item : MonoBehaviour {
    [SerializeField] private GameControlSerializableDictionary.ItemLabelObjectDictionary itemLabelObjectDictionary;
    
    private GameControlSerializableDictionary.ItemLabelTextDictionary itemLabelTextDictionary;
    private GameControlTypeManager.ItemType itemType;
    private GameControlTypeManager.ItemForgeryType itemForgeryType;
    
    private Vector2 itemInitPosition;


    private void Awake() {
        this.itemInitPosition = this.gameObject.transform.localPosition; // TODO: 위치가 안맞음!
        this.gameObject.SetActive(false);
    }
    
    public void Init(ItemScriptableObject data) {
        this.gameObject.transform.localPosition = this.itemInitPosition;
        
        this.itemType = data.itemType;
        this.itemForgeryType = data.itemForgeryType;
        
        this.itemLabelTextDictionary = new();
        this.itemLabelTextDictionary = data.itemLabelTextDictionary;

        foreach (var label in itemLabelTextDictionary) {
            this.itemLabelObjectDictionary[label.Key].text = label.Value;
        }
        
        this.gameObject.SetActive(true);
    }
}