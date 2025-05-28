public class VehicleTrainStateMove : IVehicleTrainState {
    private VehicleTrainBehaviour vehicleTrainBehaviour;
    
    
    public VehicleTrainStateMove(VehicleTrainBehaviour vehicleTrainBehaviour) {
        this.vehicleTrainBehaviour = vehicleTrainBehaviour;
    }
    
    public void Enter() {
        // Debug.Log("Entered Vehicle Train State Move");
    }

    public void Execute() {
        this.vehicleTrainBehaviour.Move();
        
        // switch (this.vehicleTrainMovementController.TrafficState) {
        //     case GameControlTypeManager.TrafficState.STOP:
        //         this.vehicleTrainMovementController.VehicleStateMachine.TransitionTo(this.vehicleTrainMovementController.VehicleStateMachine.vehicleTrainStateStop);
        //         break;
        //     case GameControlTypeManager.TrafficState.IDLE:
        //         this.vehicleTrainMovementController.VehicleStateMachine.TransitionTo(this.vehicleTrainMovementController.VehicleStateMachine.vehicleTrainStateIdle);
        //         break;
        // }
    }

    public void Exit() {
        // Debug.Log("Exited Vehicle Train State Move");
    }
}