using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ItemControlManager : MonoBehaviour {
    public UnityEvent<GameControlSerializableDictionary.ItemSaveData> OnItemRefresh;
    
    private GameControlSerializableDictionary.ItemSaveData passengerItemSaveData; 
    
    
    private void Init() {
        this.passengerItemSaveData = new();
    }
    
    public void InitPassengerItemStack(
        Stack<GameControlSerializableDictionary.ItemSaveDataScriptableObject> data) {
        foreach (var _VARIABLE in data.SelectMany(VARIABLE => VARIABLE)) {
            this.passengerItemSaveData.TryAdd(_VARIABLE.Key, new GameSaveDataItem(_VARIABLE.Value));
        }
        
        this.OnItemRefresh.Invoke(this.passengerItemSaveData);
    }

    private void Awake() {
        Init();
    }
    
    public void OnClick() {
        this.OnItemRefresh.Invoke(this.passengerItemSaveData);
    }
}