using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VehicleTrainTrafficManager : MonoBehaviour {
    [HideInInspector] public UnityEvent onTrafficTransitionToIdle;

    [HideInInspector] public UnityEvent onTrafficEnterIdle;
    [HideInInspector] public UnityEvent onTrafficEnterStop;
    // [HideInInspector] public UnityEvent onTrafficEnterMove;

    [HideInInspector] public UnityEvent onTrafficExecuteMove;
    [HideInInspector] public UnityEvent onTrafficExecuteStop;

    [HideInInspector] public UnityEvent onTrafficExitIdle;
    
    [SerializeField] private TMP_Text trafficStateTmp;
    [SerializeField] private Button trafficStateChangeButton;
    public Button investigationButton;
    
    private IVehicleTrainTrafficState nextState;
    private VehicleTrainTrafficStateManager vehicleTrainTrafficStateManager;
    
    
    private void Init() {
        this.vehicleTrainTrafficStateManager = new VehicleTrainTrafficStateManager(this);
        this.investigationButton.gameObject.SetActive(false);

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
    
    public void TrainSetActive(bool isActive) {
        if (isActive) {
            this.vehicleTrainTrafficStateManager.TransitionTo(
                this.vehicleTrainTrafficStateManager?.VehicleTrainTrafficStateMove);
        }
        else {
            this.vehicleTrainTrafficStateManager.TransitionTo(
                this.vehicleTrainTrafficStateManager?.VehicleTrainTrafficStateIdle);
        }
    }
    
    public void TrainTrafficMonitorUpdate(string stateText) {
        this.trafficStateTmp.text = stateText;
    }
}