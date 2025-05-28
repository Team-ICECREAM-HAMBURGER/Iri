public class VehicleTrainStateIdle : IVehicleTrainState {
    private VehicleTrainBehaviour vehicleTrainBehaviour;

    
    public VehicleTrainStateIdle(VehicleTrainBehaviour vehicleTrainBehaviour) {
        this.vehicleTrainBehaviour = vehicleTrainBehaviour;
    }
    
    public void Enter() {
        // Debug.Log("Entered Vehicle Train State Idle");
    }

    public void Execute() {
        this.vehicleTrainBehaviour.Idle();
    }

    public void Exit() {
        // Debug.Log("Exited Vehicle Train State Idle");
    }
}