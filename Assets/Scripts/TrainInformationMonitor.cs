using UnityEngine;
using UnityEngine.Events;

public class TrainInformationMonitor : MonoBehaviour {
    public static UnityEvent<GameControlTypeManager.VehicleTrainType, GameControlTypeManager.TrafficState, string> OnTrafficStatusUpdate;
    
    [SerializeField] private GameControlSerializableDictionary.TrafficStatus trafficStatus;
    [SerializeField] private GameControlSerializableDictionary.TrafficStatusTmp trafficStatusTmp;

    
    private void Init() {
        OnTrafficStatusUpdate = new();
        OnTrafficStatusUpdate.AddListener(TrafficStatusUpdate);
    }

    private void Awake() {
        Init();
    }

    private void TrafficStatusUpdate(GameControlTypeManager.VehicleTrainType vehicleTrainType, GameControlTypeManager.TrafficState trafficState, string trafficStatusText) {
        this.trafficStatus[vehicleTrainType] = trafficState;
        this.trafficStatusTmp[vehicleTrainType].text = trafficStatusText;
    }
}