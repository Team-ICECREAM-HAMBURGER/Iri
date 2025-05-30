using UnityEngine;

public class TrafficLightStateMove : ITrafficLightState {
    private TrafficLightBehaviour trafficLightBehaviour;


    public TrafficLightStateMove(TrafficLightBehaviour trafficLightBehaviour) {
        this.trafficLightBehaviour = trafficLightBehaviour;
    }
    
    public void Enter() {
        // Debug.Log("Enter Traffic Light State Move");
    }

    public void Execute() {
        // Debug.Log("Execute Traffic Light State Move");
        this.trafficLightBehaviour.Move();
    }

    public void Exit() {
        // Debug.Log("Exit Traffic Light State Move");
    }
}