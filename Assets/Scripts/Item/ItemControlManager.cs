using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ItemControlManager : MonoBehaviour {
    public UnityEvent<(GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveData)> OnItemRefresh;
    
    private GameControlSerializableDictionary.ItemSaveData passengerItemSaveData;
    private GameSaveDataPassenger passengerSaveData;
    
    
    private void Init() {
        this.passengerItemSaveData = new();
    }
    
    public void InitPassengerItemStack(
        Stack<(GameSaveDataPassenger, GameControlSerializableDictionary.ItemSaveDataScriptableObject)> data) {
        foreach (var _VARIABLE 
                 in data.SelectMany(VARIABLE => {
                     this.passengerSaveData = VARIABLE.Item1; return VARIABLE.Item2; })) {
            this.passengerItemSaveData.TryAdd(_VARIABLE.Key, new GameSaveDataItem(_VARIABLE.Value));
        }
        
        this.OnItemRefresh.Invoke((this.passengerSaveData, this.passengerItemSaveData));
    }

    private void Awake() {
        Init();
    }
    
    public void OnClick() {
        this.OnItemRefresh.Invoke((this.passengerSaveData, this.passengerItemSaveData));
    }
}