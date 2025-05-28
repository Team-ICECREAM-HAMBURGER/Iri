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
    }

    public void Exit() {
        // Debug.Log("Exited Vehicle Train State Move");
    }
}