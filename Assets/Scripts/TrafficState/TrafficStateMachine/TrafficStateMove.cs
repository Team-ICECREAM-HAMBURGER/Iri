using UnityEngine;

public class TrafficStateMove : ITrafficState {
    private TrafficStateBehaviour trafficStateBehaviour;


    public TrafficStateMove(TrafficStateBehaviour trafficStateBehaviour) {
        this.trafficStateBehaviour = trafficStateBehaviour;
    }
    
    public void Enter() {
        // Debug.Log("Enter Traffic Light State Move");
    }

    public void Execute() {
        // Debug.Log("Execute Traffic Light State Move");
        this.trafficStateBehaviour.Move();
    }

    public void Exit() {
        // Debug.Log("Exit Traffic Light State Move");
    }
}