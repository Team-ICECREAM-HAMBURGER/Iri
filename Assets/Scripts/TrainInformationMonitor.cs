using UnityEngine;
using UnityEngine.Events;

public class TrainInformationMonitor : MonoBehaviour {
    public static UnityEvent<GameControlTypeManager.vehicleType, GameControlTypeManager.TrafficStatus, string> OnTrafficStatusUpdate;
    
    [SerializeField] private GameControlDictionary.TrafficStatus trafficStatus;
    [SerializeField] private GameControlDictionary.TrafficStatusTmp trafficStatusTmp;

    
    private void Init() {
        OnTrafficStatusUpdate = new();
        OnTrafficStatusUpdate.AddListener(TrafficStatusUpdate);
    }

    private void Awake() {
        Init();
    }

    private void TrafficStatusUpdate(GameControlTypeManager.vehicleType vehicleType, GameControlTypeManager.TrafficStatus trafficStatus, string trafficStatusText) {
        this.trafficStatus[vehicleType] = trafficStatus;
        this.trafficStatusTmp[vehicleType].text = trafficStatusText;
    }
}