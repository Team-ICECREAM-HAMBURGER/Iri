public class VehicleTrainTrafficStateIdle : IVehicleTrainTrafficState {
    private VehicleTrainTrafficManager vehicleTrainTrafficManager;
    
    
    public VehicleTrainTrafficStateIdle(VehicleTrainTrafficManager vehicleTrainTrafficManager) {
        this.vehicleTrainTrafficManager = vehicleTrainTrafficManager;
    }
    
    public void Enter() {
        // 이벤트 발생 알림!
        this.vehicleTrainTrafficManager?.TrainTrafficMonitorUpdate("대기");
        this.vehicleTrainTrafficManager?.onTrafficEnterIdle.Invoke();
    }

    public void Execute() {
        
    }

    public void Exit() {
        this.vehicleTrainTrafficManager?.onTrafficExitIdle.Invoke();
    }
}