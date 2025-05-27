public class VehicleTrainStateStop : IVehicleTrainState {
    private VehicleTrainController vehicleTrainController;


    public VehicleTrainStateStop(VehicleTrainController vehicleTrainController) {
        this.vehicleTrainController = vehicleTrainController;
    }
    
    public void Enter() {
        // Debug.Log("Entering Vehicle Train State Stop");
    }

    public void Execute() {
        this.vehicleTrainController.Stop();

        if (this.vehicleTrainController.TrainLocationType == GameControlTypeManager.TrainLocationType.IDLE) {
            this.vehicleTrainController.VehicleStateMachine.TransitionTo(this.vehicleTrainController.VehicleStateMachine.vehicleTrainStateIdle);
        }
    }
    
    public void Exit() {
        // Debug.Log("Exiting Vehicle Train State Stop");
    }
}