public class VehicleTrainTrafficStateStop : IVehicleTrainTrafficState {
    private VehicleTrainTrafficManager vehicleTrainTrafficManager;

    
    public VehicleTrainTrafficStateStop(VehicleTrainTrafficManager vehicleTrainTrafficManager) {
        this.vehicleTrainTrafficManager = vehicleTrainTrafficManager;
    }
    
    public void Enter() {
        // 이벤트 발생 알림!
        this.vehicleTrainTrafficManager.TrainTrafficMonitorUpdate(false, "정차");
        this.vehicleTrainTrafficManager.onTrafficEnterStop.Invoke();
    }

    public void Execute() {
        this.vehicleTrainTrafficManager.onTrafficExecuteStop.Invoke();
    }

    public void Exit() {
        
    }
}