using UnityEngine;

public class TrainInvestigationButtonController : MonoBehaviour, IGameControlClickableObject {
    [SerializeField] private VehicleTrainController vehicleTrainController;
    [SerializeField] private TrainPassengerController trainPassengerController;
    
    [Space(10f)]
    
    [SerializeField] private GameObject investigationIconObject;

    
    private void Init() {
        this.investigationIconObject.SetActive(false);
        this.vehicleTrainController.OnVehicleTrainStopped.AddListener(TrainStopped);
    }

    private void Awake() {
        Init();
    }

    private void TrainStopped(GameControlTypeManager.TrafficStatus trafficStatus) {
        if (trafficStatus == GameControlTypeManager.TrafficStatus.IDLE) {
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