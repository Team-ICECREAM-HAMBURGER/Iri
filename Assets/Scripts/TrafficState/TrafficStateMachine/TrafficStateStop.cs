using UnityEngine;

public class TrafficStateStop : ITrafficState {
    private TrafficStateBehaviour trafficStateBehaviour;
    
    
    public TrafficStateStop(TrafficStateBehaviour trafficStateBehaviour) {
        this.trafficStateBehaviour = trafficStateBehaviour;
    }
    
    public void Enter() {
        // Debug.Log("Enter Traffic Light State Stop");
    }

    public void Execute() {
        // Debug.Log("Execute Traffic Light State Stop");
        this.trafficStateBehaviour.Stop();
    }

    public void Exit() {
        // Debug.Log("Exit Traffic Light State Stop");
    }
}