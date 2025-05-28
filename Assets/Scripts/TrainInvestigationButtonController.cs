using UnityEngine;
using UnityEngine.Serialization;

public class TrainInvestigationButtonController : MonoBehaviour, IGameControlClickableObject {
    [FormerlySerializedAs("vehicleTrainController")] [FormerlySerializedAs("vehicleTrainMovementController")] [SerializeField] private VehicleTrainBehaviour vehicleTrainBehaviour;
    [SerializeField] private TrainPassengerController trainPassengerController;
    
    [Space(10f)]
    
    [SerializeField] private GameObject investigationIconObject;

    
    private void Init() {
        this.investigationIconObject.SetActive(false);
        // this.vehicleTrainMovementController.OnVehicleTrainStopped.AddListener(TrainStopped);
    }

    private void Awake() {
        Init();
    }

    private void TrainStopped(GameControlTypeManager.TrafficState trafficState) {
        if (trafficState == GameControlTypeManager.TrafficState.IDLE) {
            this.investigationIconObject.SetActive(true);
        }
        else {
            this.investigationIconObject.SetActive(false);
        }
    }
    
    public void OnClick() {
        if (this.investigationIconObject.activeSelf) {
            this.trainPassengerController.OnClick();
        }
    }
}