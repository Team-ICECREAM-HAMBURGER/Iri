using System;
using UnityEngine;

public class VehicleTrainInvestigationBehaviour : MonoBehaviour {
    [SerializeField] private GameControlExpandMenuDragController gameControlExpandMenuDragController;
    [SerializeField] private VehicleTrainTrafficManager vehicleTrainTrafficManager;
    [Space(10f)] 
    [SerializeField] private Animator investigatingAnimator;
    [SerializeField] private string animationTriggerName;
    
    
    private void OnEnable() {
        this.vehicleTrainTrafficManager.isInvestigated = false;
        this.vehicleTrainTrafficManager.investigatingButton.onClick.AddListener(OnInvestigationTalk);    
    }

    private void OnDisable() {
        this.vehicleTrainTrafficManager.isInvestigated = false;
        this.vehicleTrainTrafficManager.investigatingButton.onClick.RemoveListener(OnInvestigationTalk);
    }
    
    private void OnInvestigationTalk() {
        Debug.Log("Talking...");
        
        // 말풍선
        this.investigatingAnimator.SetTrigger(this.animationTriggerName);
        // TODO: 검문 데이터 로드
        
        // 화면 자동 스크롤
        this.gameControlExpandMenuDragController.InvestigatePanelActive();

        this.vehicleTrainTrafficManager.isInvestigated = true;
    }
}