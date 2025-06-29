using System.Collections.Generic;
using UnityEngine;

public class VehicleTrainInvestigationBehaviour : MonoBehaviour {
    [SerializeField] private GameControlExpandMenuDragController gameControlExpandMenuDragController;
    [SerializeField] private VehicleTrainTrafficManager vehicleTrainTrafficManager;
    [Space(10f)] 
    [SerializeField] private Animator investigationAnimator;
    [SerializeField] private string animationTriggerName;

    [Space(25f)]
    
    [Header("Passenger Information")]
    [SerializeField] private List<PassengerScriptableObject> randomPassengerScriptableObjects;
    [SerializeField] private List<PassengerScriptableObject> targetPassengerScriptableObjects;
    
    private List<Passenger> trainPassengers;
    private int randomPassengerIndex;
    private GameControlFisherYatesShuffler gameControlFisherYatesShuffler;

    private bool isInvestigated;
    private bool isStopped;
    
    
    private void Init() {
        this.isInvestigated = false;
        this.isStopped = false;
        this.gameControlFisherYatesShuffler = new();
    }

    private void Awake() {
        Init();
    }

    private void OnEnable() {
        this.isInvestigated = false;
        this.isStopped = false;
        
        // FOR PREVENT NULL ERROR //
        // this.vehicleTrainTrafficManager.investigationButton.gameObject.SetActive(false);
        this.vehicleTrainTrafficManager.onInvestigationButtonActive.Invoke(false);
        
        this.vehicleTrainTrafficManager.investigationButton.onClick.AddListener(OnInvestigatingMessagePopup);
        this.vehicleTrainTrafficManager.onTrafficEnterStop.AddListener(OnTrainStopCheck);
        this.vehicleTrainTrafficManager.onTrafficEnterIdle.AddListener(OnInvestigationButtonActiveControl);
        this.vehicleTrainTrafficManager.onTrafficExitIdle.AddListener(OnInvestigationPass);
        
        // PassengerSOs Init
        this.trainPassengers = new();
        var passengerScriptableObjects = this.randomPassengerScriptableObjects;
        passengerScriptableObjects.AddRange(targetPassengerScriptableObjects);
        
        // Fisher–Yates Shuffle
        passengerScriptableObjects 
            = this.gameControlFisherYatesShuffler.ShuffleList(passengerScriptableObjects);
        
        // allPassengers Init
        foreach (var VARIABLE in passengerScriptableObjects) { 
            var passenger = new Passenger(VARIABLE);
            this.trainPassengers.Add(passenger);
        }
    }
    
    private void OnDisable() {
        this.isInvestigated = false;
        this.isStopped = false;
        
        // FOR PREVENT NULL ERROR //
        // this.vehicleTrainTrafficManager.investigationButton.gameObject.SetActive(false);
        this.vehicleTrainTrafficManager.onInvestigationButtonActive.Invoke(false);
        
        this.vehicleTrainTrafficManager.investigationButton.onClick.RemoveListener(OnInvestigatingMessagePopup);
        this.vehicleTrainTrafficManager.onTrafficEnterStop.RemoveListener(OnTrainStopCheck);
        this.vehicleTrainTrafficManager.onTrafficEnterIdle.RemoveListener(OnInvestigationButtonActiveControl);
        this.vehicleTrainTrafficManager.onTrafficExitIdle.RemoveListener(OnInvestigationPass);
    }

    private void OnTrainStopCheck() {
        this.isStopped = true;
    }

    private void OnInvestigationPass() {
        // FOR PREVENT NULL ERROR //
        // this.vehicleTrainTrafficManager.investigationButton.gameObject.SetActive(false);
        this.vehicleTrainTrafficManager.onInvestigationButtonActive.Invoke(false);
    }
    
    private void OnInvestigationButtonActiveControl() {
        if (this.isStopped && !this.isInvestigated) { // target
            // FOR PREVENT NULL ERROR //
            // this.vehicleTrainTrafficManager.investigationButton.gameObject.SetActive(true);
            this.vehicleTrainTrafficManager.onInvestigationButtonActive.Invoke(true);

        }
        else {
            // FOR PREVENT NULL ERROR //
            // this.vehicleTrainTrafficManager.investigationButton.gameObject.SetActive(false);
            this.vehicleTrainTrafficManager.onInvestigationButtonActive.Invoke(false);
        }
    }
    
    private void OnInvestigatingMessagePopup() {
        // 말풍선; "수사 중..."
        this.isInvestigated = true;
        this.investigationAnimator.SetTrigger(this.animationTriggerName);
        
        InvestigationDataLoad();
        
        // 화면 자동 스크롤
        this.gameControlExpandMenuDragController.InvestigatePanelActive();
        
        // 검문 버튼 OFF
        this.vehicleTrainTrafficManager.onInvestigationButtonActive.Invoke(false);
    }

    private void InvestigationDataLoad() {
        // 승객의 아이템 준비
        foreach (var passenger in this.trainPassengers) {
            passenger.PassengerItemInit();
        }
    }
}