using TMPro;
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
    [SerializeField] private Button investigatingButton;

    private IVehicleTrainTrafficState nextState;
    private VehicleTrainTrafficStateManager vehicleTrainTrafficStateManager;
    [HideInInspector] public bool isInvestigated;  
    
    
    private void Init() {
        this.isInvestigated = false;
        this.investigatingButton.gameObject.SetActive(false);
        this.vehicleTrainTrafficStateManager = new VehicleTrainTrafficStateManager(this);
        
        this.trafficStateChangeButton.onClick.AddListener(OnTrafficStateChange);
        this.investigatingButton.onClick.AddListener(OnInvestigatingStart);
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

    private void OnInvestigatingStart() {
        this.isInvestigated = true;
        // TODO: 검문 화면 자동 스크롤
    }
    
    public void TrainTrafficMonitorUpdate(bool investigationIconValue, string stateText) {
        this.trafficStateTmp.text = stateText;

        if (this.isInvestigated) {
            investigationIconValue = false;
        }

        this.investigatingButton.gameObject.SetActive(investigationIconValue);
    }
}