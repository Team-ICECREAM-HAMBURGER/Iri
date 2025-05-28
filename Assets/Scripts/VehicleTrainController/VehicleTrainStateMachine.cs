public class VehicleTrainStateMachine {
    public IVehicleTrainState CurrentTrainState { get; private set; }

    public VehicleTrainStateIdle vehicleTrainStateIdle;
    public VehicleTrainStateMove vehicleTrainStateMove;
    public VehicleTrainStateStop vehicleTrainStateStop;
    
    
    public VehicleTrainStateMachine(VehicleTrainBehaviour vehicleTrainBehaviour) {
        this.vehicleTrainStateIdle = new VehicleTrainStateIdle(vehicleTrainBehaviour);
        this.vehicleTrainStateMove = new VehicleTrainStateMove(vehicleTrainBehaviour);
        this.vehicleTrainStateStop = new VehicleTrainStateStop(vehicleTrainBehaviour);
        this.CurrentTrainState = this.vehicleTrainStateMove;
    }

    public void TransitionTo(IVehicleTrainState nextVehicleTrainState) {
        this.CurrentTrainState?.Exit();
        this.CurrentTrainState = nextVehicleTrainState;
        this.CurrentTrainState?.Enter();
    }

    public void Execute() {
        this.CurrentTrainState?.Execute();
    }
}