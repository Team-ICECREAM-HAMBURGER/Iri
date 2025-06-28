using UnityEngine;

public class Item : MonoBehaviour {
    public GameControlTypeManager.ItemType itemType;
    public GameControlTypeManager.ItemForgeryType itemForgeryType;
    public GameControlSerializableDictionary.ItemLabelObjectDictionary itemLabelObjectDictionary;

    private GameControlSerializableDictionary.ItemLabelTextDictionary itemLabelTextDictionary;
    private Vector2 itemInitPosition;


    private void Init() {
        this.itemInitPosition = this.gameObject.transform.position;
        this.gameObject.SetActive(false);
    }
    
    public void Init(ItemScriptableObject data) {
        this.gameObject.transform.position = this.itemInitPosition;
        
        this.itemType = data.itemType;
        this.itemForgeryType = data.itemForgeryType;
        
        this.itemLabelTextDictionary = new();
        this.itemLabelTextDictionary = data.itemLabelTextDictionary;

        foreach (var label in itemLabelTextDictionary) {
            this.itemLabelObjectDictionary[label.Key].text = label.Value;
        }
    }

    private void Awake() {
        Init();
    }
}