using UnityEngine;

public class VehicleTrainStateMove : IVehicleTrainState {
    private VehicleTrainController trainController;

    
    public VehicleTrainStateMove(VehicleTrainController trainController) {
        this.trainController = trainController;
    }
    
    public void Enter() {
        // Debug.Log("Entered Vehicle Train State Move");
    }

    public void Execute() {
        this.trainController.Move();

        if (this.trainController.TrafficStatus == GameControlTypeManager.TrafficStatus.STOP) {
            this.trainController.VehicleStateMachine.TransitionTo(this.trainController.VehicleStateMachine.vehicleTrainStateStop);
        }
    }

    public void Exit() {
        // Debug.Log("Exited Vehicle Train State Move");
    }
}