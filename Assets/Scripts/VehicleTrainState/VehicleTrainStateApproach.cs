public class VehicleTrainStateApproach : IVehicleTrainState {
    private VehicleTrainController vehicleTrainController;


    public VehicleTrainStateApproach(VehicleTrainController vehicleTrainController) {
        this.vehicleTrainController = vehicleTrainController;
    }
    
    public void Enter() {
        // Debug.Log("Entered Vehicle Train State Approach");
    }

    public void Execute() {
        this.vehicleTrainController.Approach();

        if (this.vehicleTrainController.TrafficStatus == GameControlTypeManager.TrafficStatus.STOP) {
            this.vehicleTrainController.VehicleStateMachine.TransitionTo(this.vehicleTrainController.VehicleStateMachine.vehicleTrainStateStop);
        }
        else if (this.vehicleTrainController.TrafficStatus == GameControlTypeManager.TrafficStatus.PASS) {
            this.vehicleTrainController.VehicleStateMachine.TransitionTo(this.vehicleTrainController.VehicleStateMachine.vehicleTrainStatePass);
        }
    }

    public void Exit() {
        // Debug.Log("Exited Vehicle Train State Approach");
    }
}