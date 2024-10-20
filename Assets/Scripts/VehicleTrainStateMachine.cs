public class VehicleTrainStateMachine {
    public IVehicleTrainState CurrentTrainState { get; private set; }

    public VehicleTrainStateIdle vehicleTrainStateIdle;
    public VehicleTrainStateMove vehicleTrainStateMove;
    public VehicleTrainStateStop vehicleTrainStateStop;
    
    
    public VehicleTrainStateMachine(VehicleTrainController vehicleTrainController) {
        this.vehicleTrainStateIdle = new VehicleTrainStateIdle(vehicleTrainController);
        this.vehicleTrainStateMove = new VehicleTrainStateMove(vehicleTrainController);
        this.vehicleTrainStateStop = new VehicleTrainStateStop(vehicleTrainController);

        this.CurrentTrainState = this.vehicleTrainStateMove;
    }

    public void Init(IVehicleTrainState initVehicleTrainStateIdle) {
        this.CurrentTrainState = initVehicleTrainStateIdle;
        this.CurrentTrainState?.Enter();
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