using UnityEngine;

public class TrafficLightStateStop : ITrafficLightState {
    private TrafficLightBehaviour trafficLightBehaviour;
    
    
    public TrafficLightStateStop(TrafficLightBehaviour trafficLightBehaviour) {
        this.trafficLightBehaviour = trafficLightBehaviour;
    }
    
    public void Enter() {
        // Debug.Log("Enter Traffic Light State Stop");
    }

    public void Execute() {
        // Debug.Log("Execute Traffic Light State Stop");
        this.trafficLightBehaviour.Stop();
    }

    public void Exit() {
        // Debug.Log("Exit Traffic Light State Stop");
    }
}