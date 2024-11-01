public class TrafficLightStateMachine {
    public ITrafficLightState CurrentTrafficLightState { get; private set; }
    
    public TrafficLightStateMove trafficLightStateMove;
    public TrafficLightStateStop trafficLightStateStop;
    public TrafficLightStateIdle trafficLightStateIdle;

    
    public TrafficLightStateMachine(TrafficLightController trafficLightController) {
        this.trafficLightStateMove = new (trafficLightController);
        this.trafficLightStateStop = new (trafficLightController);
        this.trafficLightStateIdle = new (trafficLightController);
        
        this.CurrentTrafficLightState = this.trafficLightStateStop;
    }

    public void Init(ITrafficLightState initTrafficLightState) {
        this.CurrentTrafficLightState = initTrafficLightState;
        this.CurrentTrafficLightState?.Enter();
    }
    
    public void TransitionTo(ITrafficLightState nextTrafficLightState) {
        this.CurrentTrafficLightState?.Exit();
        this.CurrentTrafficLightState = nextTrafficLightState;
        this.CurrentTrafficLightState?.Enter();
    }

    public void Execute() {
        this.CurrentTrafficLightState?.Execute();
    }
}