using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemRefreshManager : MonoBehaviour {
    [HideInInspector] public UnityEvent<Stack<GameSaveDataPassenger>> OnItemRefresh;

    [SerializeField] private GameControlSerializableDictionary.ItemData items;
    
    private Stack<GameSaveDataPassenger> passengerStack;
    

    private void Init() {
        this.passengerStack = new();

        foreach (var VARIABLE in this.items.Keys) {
            this.items[VARIABLE].gameObject.SetActive(false);
        }
    }

    private void Awake() {
        Init();
    }

    public void InitPassengerStack(Stack<GameSaveDataPassenger> passengerStack) {
        this.passengerStack = passengerStack;
        this.passengerStack.TryPop(out var passenger);
        
        foreach(var VARIABLE in passenger.itemTypes) {
            Debug.Log(VARIABLE);
            this.items[VARIABLE].gameObject.SetActive(true);
        }
    }
    
    public void OnClick() {
        this.OnItemRefresh.Invoke(this.passengerStack);
    }
}