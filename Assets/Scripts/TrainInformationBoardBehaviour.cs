using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TrainInformationBoardBehaviour : MonoBehaviour {
    [SerializeField] private GameControlTypeManager.VehicleTrainType trainType;
    
    [HideInInspector] public UnityEvent onTrafficTransitionToIdle;

    [HideInInspector] public UnityEvent onTrafficEnterIdle;
    [HideInInspector] public UnityEvent onTrafficEnterStop;

    [HideInInspector] public UnityEvent onTrafficExecuteMove;
    [HideInInspector] public UnityEvent onTrafficExecuteStop;

    [HideInInspector] public UnityEvent onTrafficExitIdle;

    [HideInInspector] public UnityEvent<bool> onInvestigationButtonActive;
    
    [SerializeField] private TMP_Text trafficStateTmp;
    [SerializeField] private Button trafficStateChangeButton;
    
    [Space(10f)]
    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text speechTextField;
    [SerializeField] private string speechText;
    [SerializeField] private string animationTriggerName;
    
    [Space(10f)]
    public Button investigationButton;
    
    private IVehicleTrainTrafficState nextState;
    private VehicleTrainTrafficStateManager vehicleTrainTrafficStateManager;
    
    
    private void Init() {
        this.vehicleTrainTrafficStateManager = new VehicleTrainTrafficStateManager(this);
        this.investigationButton.gameObject.SetActive(false);

        this.trafficStateChangeButton.onClick.AddListener(OnTrafficStateChange);
        
        this.onTrafficTransitionToIdle.AddListener(OnTrafficStateChangeToIdle);
        this.onInvestigationButtonActive.AddListener(OnInvestigationButtonActive);
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
        // 신호 전환 시도
        if (PlayerBehaviour.Instance.isInvestigating) {
            // 플레이어는 현재 검문 중, 필수 서류 제출이 이루어졌는가?
            if (PlayerBehaviour.Instance.currentInvestigatingTrainType == this.trainType) {
                // TODO: 싱글턴이라서 다른 열차까지 영향을 미침.
                this.speechTextField.text = this.speechText;
                this.animator.SetTrigger(this.animationTriggerName);
                
                return;
            }
        }

        // 신호 전환 진행 //
        if (this.vehicleTrainTrafficStateManager.CurrentVehicleTrainTrafficState 
            == this.vehicleTrainTrafficStateManager.VehicleTrainTrafficStateMove) {
            this.nextState = this.vehicleTrainTrafficStateManager.VehicleTrainTrafficStateStop;
        }
        else {
            this.nextState = this.vehicleTrainTrafficStateManager.VehicleTrainTrafficStateMove;
        }
        
        this.vehicleTrainTrafficStateManager.TransitionTo(this.nextState);
    }

    private void OnInvestigationButtonActive(bool active) {
        if (this.investigationButton != null) { // FOR PREVENT NULL ERROR
            this.investigationButton.gameObject.SetActive(active);
        }
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