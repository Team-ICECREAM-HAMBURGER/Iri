public class VehicleTrainStatePass : IVehicleTrainState {
    private VehicleTrainController vehicleTrainController;


    public VehicleTrainStatePass(VehicleTrainController vehicleTrainController) {
        this.vehicleTrainController = vehicleTrainController;
    }
    
    public void Enter() {
        
    }

    public void Execute() {
        this.vehicleTrainController.Pass();
        
        if (this.vehicleTrainController.TrafficStatus == GameControlTypeManager.TrafficStatus.STOP) {
            this.vehicleTrainController.VehicleStateMachine.TransitionTo(this.vehicleTrainController.VehicleStateMachine.vehicleTrainStateStop);
        }
        else if (this.vehicleTrainController.TrafficStatus == GameControlTypeManager.TrafficStatus.IDLE) {
            this.vehicleTrainController.VehicleStateMachine.TransitionTo(this.vehicleTrainController.VehicleStateMachine.vehicleTrainStateIdle);
        }
    }

    public void Exit() {
        
    }
}