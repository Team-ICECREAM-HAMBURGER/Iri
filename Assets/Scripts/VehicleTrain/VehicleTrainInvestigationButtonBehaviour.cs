using UnityEngine;
using UnityEngine.Events;

public class VehicleTrainInvestigationButtonBehaviour : MonoBehaviour {
    [HideInInspector] public UnityEvent OnInvestigate;

    [SerializeField] private TrafficStateBehaviour trafficStateBehaviour;
    
    private bool investigated;
        
    
    private void Init() {
        this.trafficStateBehaviour.OnTrafficUpdateStop.AddListener(InvestigationButtonActive);
        this.gameObject.SetActive(false);
        this.investigated = false;
    }

    private void Awake() {
        Init();
    }

    public void OnClick() {
        this.OnInvestigate.Invoke();    // Investigation Event Invoke
        
        this.investigated = true;
        this.gameObject.SetActive(false);
    }

    private void InvestigationButtonActive() {
        if (this.investigated) {
            return;
        }
        
        this.gameObject.SetActive(true);
    }
}