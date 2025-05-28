public class TrafficLightStateIdle : ITrafficLightState {
    private TrafficLightController trafficLightController;
    

    public TrafficLightStateIdle(TrafficLightController trafficLightController) {
        this.trafficLightController = trafficLightController;
    }
    
    public void Enter() {
        // Debug.Log("Enter Traffic Light State Idle");
    }

    public void Execute() {
        this.trafficLightController.Idle();

        if (this.trafficLightController.TrafficLightState == GameControlTypeManager.TrafficState.MOVE) {
            this.trafficLightController.TrafficLightStateMachine.TransitionTo(this.trafficLightController.TrafficLightStateMachine.trafficLightStateMove);
        }
    }

    public void Exit() {
        // Debug.Log("Exit Traffic Light State Idle");
    }
}