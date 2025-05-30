using UnityEngine;

public class TrafficLightStateIdle : ITrafficLightState {
    private TrafficLightBehaviour trafficLightBehaviour;
    

    public TrafficLightStateIdle(TrafficLightBehaviour trafficLightBehaviour) {
        this.trafficLightBehaviour = trafficLightBehaviour;
    }
    
    public void Enter() {
        // Debug.Log("Enter Traffic Light State Idle");
    }

    public void Execute() {
        // Debug.Log("Execute Traffic Light State Idle");
        this.trafficLightBehaviour.Idle();
    }

    public void Exit() {
        // Debug.Log("Exit Traffic Light State Idle");
    }
}