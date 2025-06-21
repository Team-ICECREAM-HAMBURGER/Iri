using System.Collections.Generic;
using UnityEngine;

public class ItemManager : GameControlSingleton<ItemManager> {
    // public UnityEvent<(GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData)> OnItemRefresh;
    
    // private GameControlSerializableDictionary.ItemSaveData passengerItemSaveData;
    // private GameSaveDataPassenger passengerSaveData;

    // public GameControlSerializableDictionary.ItemDictionary itemDictionary;

    public GameControlSerializableDictionary.ItemDictionary itemDictionary;
    
    
    public void Init(GameControlSerializableDictionary.ItemScriptableObjectDictionary items) {
        foreach (var VARIABLE in items) {
            this.itemDictionary[VARIABLE.Key].gameObject.SetActive(true);
        }

        // this.passengerItemSaveData = new();
    }
    
    // public void InitPassengerItemStack(Stack<(GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveDataScriptableObject)> data) {
    //     foreach (var _VARIABLE 
    //              in data.SelectMany(VARIABLE => {
    //                  this.passengerSaveData = VARIABLE.Item1; return VARIABLE.Item2; })) {
    //         this.passengerItemSaveData.TryAdd(_VARIABLE.Key, new GameSaveDataItem(_VARIABLE.Value));
    //     }
    //     
    //     this.OnItemRefresh.Invoke((this.passengerSaveData, this.passengerItemSaveData));
    // }

    // private void Awake() {
    //     Init();
    // }

    // public void OnClick() {
    //     this.OnItemRefresh.Invoke((this.passengerSaveData, this.passengerItemSaveData));
    // }
}