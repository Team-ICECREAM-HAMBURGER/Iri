public class VehicleTrainTrafficStateManager {
    public IVehicleTrainTrafficState CurrentVehicleTrainTrafficState { get; private set; }

    public VehicleTrainTrafficStateIdle VehicleTrainTrafficStateIdle { get; }
    public VehicleTrainTrafficStateMove VehicleTrainTrafficStateMove { get; }
    public VehicleTrainTrafficStateStop VehicleTrainTrafficStateStop { get; }
    
    
    public VehicleTrainTrafficStateManager(VehicleTrainTrafficManager vehicleTrainTrafficManager) {
        this.VehicleTrainTrafficStateMove = new (vehicleTrainTrafficManager);
        this.VehicleTrainTrafficStateStop = new (vehicleTrainTrafficManager);
        this.VehicleTrainTrafficStateIdle = new (vehicleTrainTrafficManager);
        TransitionTo(this.VehicleTrainTrafficStateIdle);
    }
    
    public void TransitionTo(IVehicleTrainTrafficState nextVehicleTrainTrafficState) {
        this.CurrentVehicleTrainTrafficState?.Exit();
        this.CurrentVehicleTrainTrafficState = nextVehicleTrainTrafficState;
        this.CurrentVehicleTrainTrafficState?.Enter();
    }

    public void Execute() {
        this.CurrentVehicleTrainTrafficState?.Execute();
    }
}