using UnityEngine;

public class TrainInformationStateMove : ITrainInformationState {
    private VehicleTrainController vehicleController;


    public TrainInformationStateMove(VehicleTrainController vehicleController) {
        this.vehicleController = vehicleController;
    }
    
    public void Enter() {
        throw new System.NotImplementedException();
    }

    public void Execute() {
        throw new System.NotImplementedException();
    }

    public void Exit() {
        throw new System.NotImplementedException();
    }
}
