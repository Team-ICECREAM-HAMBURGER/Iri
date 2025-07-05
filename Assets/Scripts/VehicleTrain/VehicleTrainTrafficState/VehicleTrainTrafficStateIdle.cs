public class VehicleTrainTrafficStateIdle : IVehicleTrainTrafficState {
    private TrainInformationBoardBehaviour trainInformationBoardBehaviour;
    
    
    public VehicleTrainTrafficStateIdle(TrainInformationBoardBehaviour trainInformationBoardBehaviour) {
        this.trainInformationBoardBehaviour = trainInformationBoardBehaviour;
    }
    
    public void Enter() {
        // 이벤트 발생 알림!
        this.trainInformationBoardBehaviour?.TrainTrafficMonitorUpdate("대기");
        this.trainInformationBoardBehaviour?.onTrafficEnterIdle.Invoke();
    }

    public void Execute() {
        
    }

    public void Exit() {
        this.trainInformationBoardBehaviour?.onTrafficExitIdle.Invoke();
    }
}