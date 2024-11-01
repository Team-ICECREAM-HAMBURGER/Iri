using UnityEngine;

public class TrainInformationStateStop : ITrainInformationState {
    private VehicleTrainController vehicleController;


    public TrainInformationStateStop(VehicleTrainController vehicleController) {
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