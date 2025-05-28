public class VehicleTrainStateStop : IVehicleTrainState {
    private VehicleTrainBehaviour vehicleTrainBehaviour;


    public VehicleTrainStateStop(VehicleTrainBehaviour vehicleTrainBehaviour) {
        this.vehicleTrainBehaviour = vehicleTrainBehaviour;
    }
    
    public void Enter() {
        // Debug.Log("Entering Vehicle Train State Stop");
    }

    public void Execute() {
        this.vehicleTrainBehaviour.Stop();
    }
    
    public void Exit() {
        // Debug.Log("Exiting Vehicle Train State Stop");
    }
}