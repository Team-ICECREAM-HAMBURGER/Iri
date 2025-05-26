using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class TrainInvestigationButtonManager : MonoBehaviour {
    [SerializeField] private VehicleTrainController vehicleTrainController;
    [SerializeField] private List<TrainInvestigationButtonController> trainInvestigationButtonControllers;

    [HideInInspector] public UnityEvent<TrainInvestigationButtonController, GameControlTypeManager.TrafficStatus> OnTrainStopped;
    
    private int currentTrainInvestigationIndex;
    
    
    private void Init() {
        this.vehicleTrainController.OnVehicleTrainStopped.AddListener(TrainStopped);
        this.currentTrainInvestigationIndex = Random.Range(0, this.trainInvestigationButtonControllers.Count);
    }
    
    private void Awake() {
        Init();
    }

    private void TrainStopped(GameControlTypeManager.TrafficStatus trafficStatus) {
        OnTrainStopped.Invoke(this.trainInvestigationButtonControllers[this.currentTrainInvestigationIndex], trafficStatus);
    }
}