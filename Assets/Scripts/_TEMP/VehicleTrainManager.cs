using UnityEngine;

public class VehicleTrainManager : MonoBehaviour {
    // [field: SerializeField] public GameControlTypeManager.VehicleTrainType VehicleTrainType { get; set; }
    // [field: SerializeField] public GameControlTypeManager.VehicleTrainType VehicleTrainType { get; set; }
    // [SerializeField] private GameControlSerializableDictionary.TrafficStatusText trafficStatusText;
    
    // [Header("Game System Component")]
    // public TrafficLightManager trafficLightManager;
    // public TrainSpawnManager trainSpawnManager;
    
    // private void OnEnable() {
    //     OnTrafficStatusUpdate(this.TrafficStatus);
    // }
    //
    // private void OnDisable() {
    //     OnTrafficStatusUpdate(GameControlTypeManager.TrafficStatus.MOVE);
    //     
    //     this.vehicleRigidbody.linearVelocity = Vector3.zero;
    //     this.trafficApproachTrigger.OnTriggerSwitch?.Invoke();
    //     this.trafficPassTrigger.OnTriggerSwitch?.Invoke();
    // }
    //
    // private void Reset() {
    //     OnTrafficStatusUpdate(GameControlTypeManager.TrafficState.MOVE);
    //     
    //     this.vehicleRigidbody.linearVelocity = Vector3.zero;
    //     this.trafficApproachTrigger.OnTriggerSwitch?.Invoke();
    //     this.trafficPassTrigger.OnTriggerSwitch?.Invoke();
    // }        
    //
    // private void TransformReset(string trainTag) {
    //     if (!trainTag.Equals(this.gameObject.tag)) {
    //         return;
    //     }
    //     
    //     this.engineCar.transform.SetLocalPositionAndRotation(this.engineCarResetPosition, Quaternion.identity);
    //     
    //     for (var i = 0; i < this.jointCars.Count(); i++) {
    //         this.jointCars[i].transform.SetLocalPositionAndRotation(this.jointCarResetPositions[i], Quaternion.identity);
    //     }
    // }
    //
    // private void OnTrafficStatusUpdate(GameControlTypeManager.TrafficState trafficStateType) {
    //     this.trafficState = trafficStateType;
    //     TrainInformationMonitor.OnTrafficStatusUpdate.Invoke(this.VehicleTrainType, this.trafficState, this.trafficStatusText[this.trafficState]);
    //     
    //     this.OnVehicleTrainStopped.Invoke(this.trafficState);
    // }

    // this.trafficLightManager.OnTrafficStatusControl.AddListener(OnTrafficStatusUpdate);
    // this.trafficApproachTrigger.OnTrafficApproach.AddListener(OnTrafficStatusUpdate);
    // this.trafficPassTrigger.OnTrafficApproach.AddListener(OnTrafficStatusUpdate);
    // this.trainSpawnManager.OnTransformReset.AddListener(OnTransformReset);
}