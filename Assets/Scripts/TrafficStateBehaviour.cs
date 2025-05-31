using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TrafficStateBehaviour : MonoBehaviour {
    [HideInInspector] public UnityEvent OnTrafficUpdateIdle;
    [HideInInspector] public UnityEvent OnTrafficUpdateMove;
    [HideInInspector] public UnityEvent OnTrafficUpdateStop;
    
    private TrafficStateMachine trafficStateMachine;
    
    
    private void Init() {
        this.trafficStateMachine = new TrafficStateMachine(this);
    }

    private void Awake() {
        Init();
    }

    private void FixedUpdate() {
        this.trafficStateMachine?.Execute();
    }

    public void OnClick() {
        ITrafficState state = 
            (this.trafficStateMachine.CurrentTrafficState == this.trafficStateMachine.trafficStateMove) ? 
                this.trafficStateMachine.trafficStateStop : this.trafficStateMachine.trafficStateMove;
        
        this.trafficStateMachine?.TransitionTo(state);
    }

    public void Idle() {
        this.OnTrafficUpdateIdle.Invoke();
    }

    public void Move() {
        this.OnTrafficUpdateMove.Invoke();
    }

    public void Stop() {        
        this.OnTrafficUpdateStop.Invoke();
        StartCoroutine(IdleRoutine());
    }

    private IEnumerator IdleRoutine() {
        yield return new WaitForSeconds(2.5f);
        this.trafficStateMachine?.TransitionTo(this.trafficStateMachine.trafficStateIdle);
    }
}