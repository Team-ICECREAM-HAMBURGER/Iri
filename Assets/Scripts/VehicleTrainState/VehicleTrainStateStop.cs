using UnityEngine;

public class VehicleTrainStateStop : IVehicleTrainState {
    private VehicleTrainController trainController;


    public VehicleTrainStateStop(VehicleTrainController trainController) {
        this.trainController = trainController;
    }
    
    public void Enter() {
        Debug.Log("Entering Vehicle Train State Stop");
    }

    public void Execute() {
        this.trainController.Stop();
        
        if (this.trainController.VehicleStatus == GameControlTypeManager.vehicleStatus.IDLE) {
            this.trainController.VehicleStateMachine.TransitionTo(this.trainController.VehicleStateMachine.vehicleTrainStateIdle);
        }
        else if (this.trainController.VehicleStatus == GameControlTypeManager.vehicleStatus.MOVE) {
            this.trainController.VehicleStateMachine.TransitionTo(this.trainController.VehicleStateMachine.vehicleTrainStateMove);
        }
    }

    public void Exit() {
        Debug.Log("Exiting Vehicle Train State Stop");
    }
}