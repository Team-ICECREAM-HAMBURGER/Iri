public class TrafficLightStateMachine {
    public ITrafficLightState CurrentTrafficLightState { get; private set; }
    
    public TrafficLightStateMove trafficLightStateMove;
    public TrafficLightStateStop trafficLightStateStop;
    public TrafficLightStateIdle trafficLightStateIdle;

    public TrafficLightStateMachine(TrafficLightController trafficLightController) {
        this.trafficLightStateMove = new TrafficLightStateMove(trafficLightController);
        this.trafficLightStateStop = new TrafficLightStateStop(trafficLightController);
        this.trafficLightStateIdle = new TrafficLightStateIdle(trafficLightController);
        
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