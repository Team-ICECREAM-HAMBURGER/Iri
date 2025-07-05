using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class VehicleTrainInvestigationBehaviour : MonoBehaviour {
    [SerializeField] private GameControlExpandMenuDragController gameControlExpandMenuDragController;
    [SerializeField] private TrainInformationBoardBehaviour trainInformationBoardBehaviour;
    [Space(10f)] 
    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text speechTextField;
    [SerializeField] private string speechText;
    [SerializeField] private string animationTriggerName;
    [Space(10f)]
    [SerializeField] private GameControlTypeManager.VehicleTrainType vehicleType;
    
    [Space(25f)]
    
    [Header("Passenger Information")]
    [SerializeField] private List<PassengerScriptableObject> randomPassengerScriptableObjects;
    [SerializeField] private List<PassengerScriptableObject> targetPassengerScriptableObjects;
    
    private List<Passenger> trainPassengers;
    private GameControlFisherYatesShuffler gameControlFisherYatesShuffler;
    private GameControlTypeManager.InvestigateResultType investigateResult;
    private int randomPassengerIndex;
    private bool isInvestigatedTrain;
    private bool isStopped;
    
    
    private void Init() {
        this.isInvestigatedTrain = false;
        this.isStopped = false;
        this.gameControlFisherYatesShuffler = new();
    }

    private void Awake() {
        Init();
    }

    private void OnEnable() {
        this.isInvestigatedTrain = false;
        this.isStopped = false;

        this.trainInformationBoardBehaviour.onInvestigationButtonActive.Invoke(false);
        
        this.trainInformationBoardBehaviour.investigationButton.onClick.AddListener(OnInvestigatingMessagePopup);
        this.trainInformationBoardBehaviour.onTrafficEnterStop.AddListener(OnTrainStopCheck);
        this.trainInformationBoardBehaviour.onTrafficEnterIdle.AddListener(OnInvestigationButtonActiveControl);
        this.trainInformationBoardBehaviour.onTrafficExitIdle.AddListener(OnInvestigationPass);
        
        // Passengers Init
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
        this.isInvestigatedTrain = false;
        this.isStopped = false;

        
        this.trainInformationBoardBehaviour.onInvestigationButtonActive.Invoke(false);
        
        this.trainInformationBoardBehaviour.investigationButton.onClick.RemoveListener(OnInvestigatingMessagePopup);
        this.trainInformationBoardBehaviour.onTrafficEnterStop.RemoveListener(OnTrainStopCheck);
        this.trainInformationBoardBehaviour.onTrafficEnterIdle.RemoveListener(OnInvestigationButtonActiveControl);
        this.trainInformationBoardBehaviour.onTrafficExitIdle.RemoveListener(OnInvestigationPass);
    }

    private void OnTrainStopCheck() {
        this.isStopped = true;
    }

    private void OnInvestigationPass() {
        // 신호 전환 성공 시 //
        if (PlayerBehaviour.Instance.isInvestigating) {
            this.investigateResult = ItemInvestigateManager.Instance.InvestigationResult();
            
            if (this.investigateResult != GameControlTypeManager.InvestigateResultType.이상없음) {
                Debug.Log("검문오류: " + this.investigateResult);
                // TODO: 검문 오류 시 행동 처리
            }
            else {
                Debug.Log("검문성공!");
            }
        }
        
        PlayerBehaviour.Instance.isInvestigating = false;
        this.trainInformationBoardBehaviour.onInvestigationButtonActive.Invoke(false);
    }
    
    private void OnInvestigationButtonActiveControl() {
        if (this.isStopped && !this.isInvestigatedTrain) { // target
            this.trainInformationBoardBehaviour.onInvestigationButtonActive.Invoke(true);

        }
        else {
            this.trainInformationBoardBehaviour.onInvestigationButtonActive.Invoke(false);
        }
    }
    
    private void OnInvestigatingMessagePopup() {
        // 열차 수색은 1번에 1대만 가능
        if (PlayerBehaviour.Instance.isInvestigating) {
            return;
        }
        
        PlayerBehaviour.Instance.isInvestigating = true;
        
        // 말풍선; "수사 중..."
        this.isInvestigatedTrain = true;
        this.speechTextField.text = this.speechText;
        this.animator.SetTrigger(this.animationTriggerName);
        
        InvestigationDataLoad();
        
        // 화면 자동 스크롤
        this.gameControlExpandMenuDragController.InvestigatePanelActive();
        
        // 검문 버튼 OFF
        this.trainInformationBoardBehaviour.onInvestigationButtonActive.Invoke(false);
    }

    private void InvestigationDataLoad() {
        // 승객의 아이템 준비
        foreach (var passenger in this.trainPassengers) {
            passenger.PassengerItemInit();
        }
    }
}