using UnityEngine;

public class VehicleTrainInvestigationBehaviour : MonoBehaviour {
    [SerializeField] private GameControlExpandMenuDragController gameControlExpandMenuDragController;
    [SerializeField] private VehicleTrainTrafficManager vehicleTrainTrafficManager;
    [Space(10f)] 
    [SerializeField] private Animator investigationAnimator;
    [SerializeField] private string animationTriggerName;

    private bool isInvestigated;
    private bool isStopped;

    private bool isQuit;

    
    private void OnApplicationQuit() {
        this.isQuit = true;
    }
    
    private void Init() {
        this.isInvestigated = false;
        this.isStopped = false;
    }

    private void Awake() {
        Init();
    }

    private void OnEnable() {
        this.isInvestigated = false;
        this.isStopped = false;
        this.vehicleTrainTrafficManager.investigationButton.gameObject.SetActive(false);
        
        this.vehicleTrainTrafficManager.investigationButton.onClick.AddListener(OnInvestigatingMessagePopup);
        this.vehicleTrainTrafficManager.onTrafficEnterStop.AddListener(OnTrainStopCheck);
        this.vehicleTrainTrafficManager.onTrafficEnterIdle.AddListener(OnInvestigationButtonActiveControl);
        this.vehicleTrainTrafficManager.onTrafficExitIdle.AddListener(OnInvestigationPass);
    }

    private void OnDisable() {
#if UNITY_EDITOR
        if (!Application.isPlaying) {
            return;
        }
#endif
        if (GameControlApplicationQuitChecker.IsQuit) {
            return;
        }
        
        this.isInvestigated = false;
        this.isStopped = false;
        this.vehicleTrainTrafficManager.investigationButton?.gameObject.SetActive(false);
        
        this.vehicleTrainTrafficManager.investigationButton?.onClick.RemoveListener(OnInvestigatingMessagePopup);
        this.vehicleTrainTrafficManager?.onTrafficEnterStop.RemoveListener(OnTrainStopCheck);
        this.vehicleTrainTrafficManager?.onTrafficEnterIdle.RemoveListener(OnInvestigationButtonActiveControl);
        this.vehicleTrainTrafficManager?.onTrafficExitIdle.RemoveListener(OnInvestigationPass);
    }

    private void OnTrainStopCheck() {
        this.isStopped = true;
    }

    private void OnInvestigationPass() {
        this.vehicleTrainTrafficManager.investigationButton?.gameObject.SetActive(false);
    }
    
    private void OnInvestigationButtonActiveControl() {
        if (this.isStopped && !this.isInvestigated) { // target
            this.vehicleTrainTrafficManager.investigationButton?.gameObject.SetActive(true);
        }
        else {
            this.vehicleTrainTrafficManager.investigationButton?.gameObject.SetActive(false);
        }
    }
    
    private void OnInvestigatingMessagePopup() {
        // 말풍선; "수사 중..."
        this.isInvestigated = true;
        this.investigationAnimator.SetTrigger(this.animationTriggerName);
        
        // TODO: 검문 데이터 로드
        
        // 화면 자동 스크롤
        this.gameControlExpandMenuDragController.InvestigatePanelActive();
    }
}