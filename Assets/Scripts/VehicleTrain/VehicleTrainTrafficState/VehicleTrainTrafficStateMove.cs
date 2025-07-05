public class VehicleTrainTrafficStateMove : IVehicleTrainTrafficState {
    private TrainInformationBoardBehaviour trainInformationBoardBehaviour;

    
    public VehicleTrainTrafficStateMove(TrainInformationBoardBehaviour trainInformationBoardBehaviour) {
        this.trainInformationBoardBehaviour = trainInformationBoardBehaviour;
    }
    
    public void Enter() {
        // 이벤트 발생 알림!
        this.trainInformationBoardBehaviour?.TrainTrafficMonitorUpdate("이동");
    }

    public void Execute() {
        this.trainInformationBoardBehaviour?.onTrafficExecuteMove.Invoke();
    }

    public void Exit() {
    }
}