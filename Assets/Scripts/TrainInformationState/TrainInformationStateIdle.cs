using UnityEngine;

public class TrainInformationStateIdle : ITrainInformationState {
    private VehicleTrainController vehicleController;


    public TrainInformationStateIdle(VehicleTrainController vehicleController) {
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
