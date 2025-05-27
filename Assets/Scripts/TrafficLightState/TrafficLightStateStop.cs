using System.Collections;
using UnityEngine;

public class TrafficLightStateStop : ITrafficLightState {
    private TrafficLightController trafficLightController;
    
    
    public TrafficLightStateStop(TrafficLightController trafficLightController) {
        this.trafficLightController = trafficLightController;
    }
    
    public void Enter() {
        // Debug.Log("Enter Traffic Light State Stop");
    }

    public void Execute() {
        this.trafficLightController.Stop();

        if (this.trafficLightController.TrafficLightStatus == GameControlTypeManager.TrainLocationType.IDLE) {
            this.trafficLightController.TrafficLightStateMachine.TransitionTo(this.trafficLightController.TrafficLightStateMachine.trafficLightStateIdle);
        }
    }

    public void Exit() {
        // Debug.Log("Exit Traffic Light State Stop");
    }
}