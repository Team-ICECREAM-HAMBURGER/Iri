public class TrafficLightStateMove : ITrafficLightState {
    private TrafficLightController trafficLightController;


    public TrafficLightStateMove(TrafficLightController trafficLightController) {
        this.trafficLightController = trafficLightController;
    }
    
    public void Enter() {
        // Debug.Log("Enter Traffic Light State Move");
    }

    public void Execute() {
        this.trafficLightController.Move();

        if (this.trafficLightController.TrafficLightState == GameControlTypeManager.TrafficState.STOP) {
            this.trafficLightController.TrafficLightStateMachine.TransitionTo(this.trafficLightController.TrafficLightStateMachine.trafficLightStateStop);
        }
    }

    public void Exit() {
        // Debug.Log("Exit Traffic Light State Move");
    }
}