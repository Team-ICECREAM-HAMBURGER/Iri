using UnityEngine;

public class TrainInvestigationButtonController : MonoBehaviour, IGameControlClickableObject {
    [SerializeField] private TrainPassengerController trainPassengerController;
    [SerializeField] private TrainInvestigationButtonManager trainInvestigationButtonManager;
    
    [Space(10f)]
    
    [SerializeField] private GameObject investigationIconObject;

    
    private void Init() {
        this.investigationIconObject.SetActive(false);
        this.trainInvestigationButtonManager.OnTrainStopped.AddListener(ButtonSetActive);
    }

    private void Start() {
        Init();
    }

    private void ButtonSetActive(TrainInvestigationButtonController obj, GameControlTypeManager.TrainLocationType tp) {
        if (this == obj && tp == GameControlTypeManager.TrainLocationType.IDLE) {
            this.investigationIconObject.SetActive(true);
        }
        else {
            this.investigationIconObject.SetActive(false);
        }
    }
    
    public void OnClick() {
        if (this.investigationIconObject.activeSelf) {
            this.trainPassengerController.OnClick();
        }
    }
}