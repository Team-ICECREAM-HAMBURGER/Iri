public class VehicleTrainTrafficStateManager {
    public IVehicleTrainTrafficState CurrentVehicleTrainTrafficState { get; private set; }

    public VehicleTrainTrafficStateIdle VehicleTrainTrafficStateIdle { get; }
    public VehicleTrainTrafficStateMove VehicleTrainTrafficStateMove { get; }
    public VehicleTrainTrafficStateStop VehicleTrainTrafficStateStop { get; }
    
    
    public VehicleTrainTrafficStateManager(TrainInformationBoardBehaviour trainInformationBoardBehaviour) {
        this.VehicleTrainTrafficStateMove = new (trainInformationBoardBehaviour);
        this.VehicleTrainTrafficStateStop = new (trainInformationBoardBehaviour);
        this.VehicleTrainTrafficStateIdle = new (trainInformationBoardBehaviour);
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