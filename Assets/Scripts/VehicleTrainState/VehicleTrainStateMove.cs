public class VehicleTrainStateMove : IVehicleTrainState {
    private VehicleTrainController vehicleTrainController;

    
    public VehicleTrainStateMove(VehicleTrainController vehicleTrainController) {
        this.vehicleTrainController = vehicleTrainController;
    }
    
    public void Enter() {
        // Debug.Log("Entered Vehicle Train State Move");
    }

    public void Execute() {
        this.vehicleTrainController.Move();
        
        if (this.vehicleTrainController.TrainLocationType == GameControlTypeManager.TrainLocationType.STOP) {
            this.vehicleTrainController.VehicleStateMachine.TransitionTo(this.vehicleTrainController.VehicleStateMachine.vehicleTrainStateStop);
        }
        else if (this.vehicleTrainController.TrainLocationType == GameControlTypeManager.TrainLocationType.IDLE) {
            this.vehicleTrainController.VehicleStateMachine.TransitionTo(this.vehicleTrainController.VehicleStateMachine.vehicleTrainStateIdle);
        }
    }

    public void Exit() {
        // Debug.Log("Exited Vehicle Train State Move");
    }
}