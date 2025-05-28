using UnityEngine;
using UnityEngine.Events;

public class TrainInfoMonitorBehaviour : MonoBehaviour {
    public static UnityEvent<GameControlTypeManager.VehicleTrainType, 
        GameControlTypeManager.TrafficState> OnTrafficStatusUpdate;
    
    [Header("Required Components")]
    [SerializeField] private GameControlSerializableDictionary.TrafficStatusTmp trafficStatusTmp;
    [SerializeField] private GameControlSerializableDictionary.TrafficStatusText trafficStatusText;
    
    
    private void Init() {
        OnTrafficStatusUpdate = new();
        OnTrafficStatusUpdate.AddListener(TrafficStatusUpdate);
    }

    private void Awake() {
        Init();
    }

    private void TrafficStatusUpdate(GameControlTypeManager.VehicleTrainType vehicleTrainType, 
        GameControlTypeManager.TrafficState trafficState) {
        this.trafficStatusTmp[vehicleTrainType].text = this.trafficStatusText[trafficState];
    }
}