public class VehicleTrainStateIdle : IVehicleTrainState {
    private VehicleTrainController vehicleTrainController;

    
    public VehicleTrainStateIdle(VehicleTrainController vehicleTrainController) {
        this.vehicleTrainController = vehicleTrainController;
    }
    
    public void Enter() {
        // Debug.Log("Entered Vehicle Train State Idle");
    }

    public void Execute() {
        this.vehicleTrainController.Idle();
        
        if (this.vehicleTrainController.TrainLocationType == GameControlTypeManager.TrainLocationType.MOVE) {
            this.vehicleTrainController.VehicleStateMachine.TransitionTo(this.vehicleTrainController.VehicleStateMachine.vehicleTrainStateMove);
        }
    }

    public void Exit() {
        // Debug.Log("Exited Vehicle Train State Idle");
    }
}