using UnityEngine;

public class VehicleTrainStateIdle : IVehicleTrainState {
    private VehicleTrainController trainController;

    
    public VehicleTrainStateIdle(VehicleTrainController trainController) {
        this.trainController = trainController;
    }
    
    public void Enter() {
        Debug.Log("Entered Vehicle Train State Idle");
    }

    public void Execute() {
        this.trainController.Idle();
        
        if (this.trainController.TrafficStatus == GameControlTypeManager.TrafficStatus.MOVE) {
            this.trainController.VehicleStateMachine.TransitionTo(this.trainController.VehicleStateMachine.vehicleTrainStateMove);
        }
    }

    public void Exit() {
        Debug.Log("Exited Vehicle Train State Idle");
    }
}