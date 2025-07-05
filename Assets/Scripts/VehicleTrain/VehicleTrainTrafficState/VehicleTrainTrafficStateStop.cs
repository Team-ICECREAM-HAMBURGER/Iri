public class VehicleTrainTrafficStateStop : IVehicleTrainTrafficState {
    private TrainInformationBoardBehaviour trainInformationBoardBehaviour;

    
    public VehicleTrainTrafficStateStop(TrainInformationBoardBehaviour trainInformationBoardBehaviour) {
        this.trainInformationBoardBehaviour = trainInformationBoardBehaviour;
    }
    
    public void Enter() {
        // 이벤트 발생 알림!
        this.trainInformationBoardBehaviour?.TrainTrafficMonitorUpdate("정차");
        this.trainInformationBoardBehaviour?.onTrafficEnterStop.Invoke();
    }

    public void Execute() {
        this.trainInformationBoardBehaviour?.onTrafficExecuteStop.Invoke();
    }

    public void Exit() {
        
    }
}