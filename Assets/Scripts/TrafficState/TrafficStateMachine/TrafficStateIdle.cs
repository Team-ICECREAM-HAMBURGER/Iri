using UnityEngine;

public class TrafficStateIdle : ITrafficState {
    private TrafficStateBehaviour trafficStateBehaviour;
    

    public TrafficStateIdle(TrafficStateBehaviour trafficStateBehaviour) {
        this.trafficStateBehaviour = trafficStateBehaviour;
    }
    
    public void Enter() {
        // Debug.Log("Enter Traffic Light State Idle");
    }

    public void Execute() {
        // Debug.Log("Execute Traffic Light State Idle");
        this.trafficStateBehaviour.Idle();
    }

    public void Exit() {
        // Debug.Log("Exit Traffic Light State Idle");
    }
}