public class VehicleTrainStateMachine {
    public IVehicleTrainState CurrentTrainState { get; private set; }

    public VehicleTrainStateIdle vehicleTrainStateIdle;
    public VehicleTrainStateMove vehicleTrainStateMove;
    public VehicleTrainStateStop vehicleTrainStateStop;
    public VehicleTrainStateApproach vehicleTrainStateApproach;
    public VehicleTrainStatePass vehicleTrainStatePass;
    
    
    public VehicleTrainStateMachine(VehicleTrainController vehicleTrainController) {
        this.vehicleTrainStateIdle = new VehicleTrainStateIdle(vehicleTrainController);
        this.vehicleTrainStateMove = new VehicleTrainStateMove(vehicleTrainController);
        this.vehicleTrainStateStop = new VehicleTrainStateStop(vehicleTrainController);
        this.vehicleTrainStateApproach = new VehicleTrainStateApproach(vehicleTrainController);
        this.vehicleTrainStatePass = new VehicleTrainStatePass(vehicleTrainController);
        
        this.CurrentTrainState = this.vehicleTrainStateStop;
    }

    public void Init(IVehicleTrainState initVehicleTrainState) {
        this.CurrentTrainState = initVehicleTrainState;
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