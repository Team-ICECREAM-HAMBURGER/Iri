public class VehicleTrainTrafficStateMove : IVehicleTrainTrafficState {
    private VehicleTrainTrafficManager vehicleTrainTrafficManager;

    
    public VehicleTrainTrafficStateMove(VehicleTrainTrafficManager vehicleTrainTrafficManager) {
        this.vehicleTrainTrafficManager = vehicleTrainTrafficManager;
    }
    
    public void Enter() {
        // 이벤트 발생 알림!
    }

    public void Execute() {
        this.vehicleTrainTrafficManager.onTrafficExecuteMove.Invoke();
    }

    public void Exit() {
    }
}