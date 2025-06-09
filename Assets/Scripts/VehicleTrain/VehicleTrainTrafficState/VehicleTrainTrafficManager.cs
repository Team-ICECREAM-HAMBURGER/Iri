using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class VehicleTrainTrafficManager : MonoBehaviour {
    [HideInInspector] public UnityEvent onTrafficTransitionToIdle;

    [HideInInspector] public UnityEvent onTrafficEnterIdle;
    [HideInInspector] public UnityEvent onTrafficEnterStop;

    [HideInInspector] public UnityEvent onTrafficExecuteMove;
    [HideInInspector] public UnityEvent onTrafficExecuteStop;
    
    [SerializeField] private Image investigatingIcon;
    private Button trafficStateChangeButton;

    private IVehicleTrainTrafficState nextState;
    private VehicleTrainTrafficStateManager vehicleTrainTrafficStateManager;
    

    private void Init() {
        this.vehicleTrainTrafficStateManager = new VehicleTrainTrafficStateManager(this);
        this.trafficStateChangeButton = this.gameObject.GetComponent<Button>();
        
        this.trafficStateChangeButton.onClick.AddListener(OnTrafficStateChange);
        this.onTrafficTransitionToIdle.AddListener(OnTrafficStateChangeToIdle);
    }

    private void Awake() {
        Init();
    }

    private void FixedUpdate() {
        this.vehicleTrainTrafficStateManager?.Execute();
    }

    private void OnTrafficStateChangeToIdle() {
        this.vehicleTrainTrafficStateManager.TransitionTo(
            this.vehicleTrainTrafficStateManager.VehicleTrainTrafficStateIdle);
    }
    
    private void OnTrafficStateChange() {
        if (this.vehicleTrainTrafficStateManager.CurrentVehicleTrainTrafficState 
            == this.vehicleTrainTrafficStateManager.VehicleTrainTrafficStateMove) {
            this.nextState = this.vehicleTrainTrafficStateManager.VehicleTrainTrafficStateStop;
        }
        else {
            this.nextState = this.vehicleTrainTrafficStateManager.VehicleTrainTrafficStateMove;
        }
        
        this.vehicleTrainTrafficStateManager.TransitionTo(this.nextState);
    }
}