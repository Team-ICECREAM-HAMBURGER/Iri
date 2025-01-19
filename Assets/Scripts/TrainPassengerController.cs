using System.Collections.Generic;
using UnityEngine;

public class TrainPassengerController : MonoBehaviour {
    [SerializeField] private VehicleTrainController vehicleTrainController;
    [SerializeField] private GameSaveDataManager gameSaveDataManager;
    [SerializeField] private ItemRefreshManager itemRefreshManager;
    
    private List<GameSaveDataPassenger> passengers;
    private Stack<GameSaveDataPassenger> targetPassengers;
    private GameControlTypeManager.vehicleType vehicleType;
    
    
    private void Init() {
        this.vehicleType = this.vehicleTrainController.VehicleType;
        this.passengers = new();
        this.targetPassengers = new();
    }

    private void Awake() {
        Init();
    }
    
    public void OnClick() {
        var passengerNumber = Random.Range(1, 3);
        var weightTotal = 0f;
        var weights = new List<(GameSaveDataPassenger, float)>();
        
        // TODO: 이벤트성 승객 등장 처리; (탈영병 등)
        // this.targetPassengers.Push();
        
        // 일반 승객 등장 처리; (무작위 등장 승객)
        foreach (var VARIABLE 
                 in this.gameSaveDataManager.HeadChapterData.passengerScriptableObjects) {
            if (this.vehicleType == VARIABLE.vehicleType) {
                var obj = new GameSaveDataPassenger(VARIABLE);
                
                this.passengers.Add(obj);
                weightTotal += obj.weight;
            }
        }

        foreach (var VARIABLE in this.passengers) {
            weights.Add((VARIABLE, (VARIABLE.weight / weightTotal)));
        }
        
        weights.Sort((x, y) => x.Item2.CompareTo(y.Item2));
        
        for (var i = 0; i < passengerNumber; i++) {
            var weightPivot = Random.Range(0f, 1f);
            var weightSum = 0f;

            foreach (var VARIABLE in weights) {
                weightSum += VARIABLE.Item2;

                if (weightSum >= weightPivot) {
                    this.targetPassengers.Push(VARIABLE.Item1);
                    break;
                }
            }
        }
        
        this.itemRefreshManager.InitPassengerStack(this.targetPassengers);
    }
}