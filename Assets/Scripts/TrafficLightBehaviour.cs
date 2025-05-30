using System;
using UnityEngine;
using UnityEngine.Events;

public class TrafficLightBehaviour : MonoBehaviour {
    [HideInInspector] public UnityEvent OnTrafficUpdateIdle;
    [HideInInspector] public UnityEvent OnTrafficUpdateMove;
    [HideInInspector] public UnityEvent OnTrafficUpdateStop;
    
    private TrafficLightStateMachine trafficLightStateMachine;
    
    
    private void Init() {
        this.trafficLightStateMachine = new TrafficLightStateMachine(this);
    }

    private void Awake() {
        Init();
    }

    private void FixedUpdate() {
        this.trafficLightStateMachine?.Execute();
    }

    public void OnClick() {
        ITrafficLightState state = 
            (this.trafficLightStateMachine.CurrentTrafficLightState == 
             this.trafficLightStateMachine.trafficLightStateMove) ? 
                this.trafficLightStateMachine.trafficLightStateStop : 
                this.trafficLightStateMachine.trafficLightStateMove;
        
        this.trafficLightStateMachine?.TransitionTo(state);
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