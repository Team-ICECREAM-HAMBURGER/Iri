using UnityEngine;
using UnityEngine.Events;

public class TrafficStateBehaviour : MonoBehaviour {
    [HideInInspector] public UnityEvent OnTrafficUpdateIdle;
    [HideInInspector] public UnityEvent OnTrafficUpdateMove;
    [HideInInspector] public UnityEvent OnTrafficUpdateStop;
    
    [SerializeField] private VehicleTrainInvestigationButtonBehaviour vehicleTrainInvestigationButtonBehaviour;
    
    private TrafficStateMachine trafficStateMachine;
    

    private void Init() {
        this.trafficStateMachine = new TrafficStateMachine(this);
        this.vehicleTrainInvestigationButtonBehaviour.OnInvestigate.AddListener(TransitionToIdle);
    }

    private void Awake() {
        Init();
    }

    private void FixedUpdate() {
        this.trafficStateMachine?.Execute();
    }

    public void OnClick() {
        var nextState = this.trafficStateMachine.CurrentTrafficState;
        
        if (nextState == this.trafficStateMachine.trafficStateMove) {
            nextState = this.trafficStateMachine.trafficStateStop;
        }
        else {
            nextState = this.trafficStateMachine.trafficStateMove;
        }
        
        this.trafficStateMachine.TransitionTo(nextState);
    }

    private void TransitionToIdle() {   // For Investigation
        this.trafficStateMachine.TransitionTo(this.trafficStateMachine.trafficStateIdle);
    }
    
    public void Idle() {
        this.OnTrafficUpdateIdle.Invoke();
    }

    public void Move() {
        this.OnTrafficUpdateMove.Invoke();
    }

    public void Stop() {        
        this.OnTrafficUpdateStop.Invoke();
    }
}