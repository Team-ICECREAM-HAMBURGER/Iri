public class TrafficLightStateMachine {
    public ITrafficLightState CurrentTrafficLightState { get; private set; }

    public TrafficLightStateIdle trafficLightStateIdle;
    public TrafficLightStateMove trafficLightStateMove;
    public TrafficLightStateStop trafficLightStateStop;


    
    public TrafficLightStateMachine(TrafficLightBehaviour trafficLightBehaviour) {
        this.trafficLightStateMove = new (trafficLightBehaviour);
        this.trafficLightStateStop = new (trafficLightBehaviour);
        this.trafficLightStateIdle = new (trafficLightBehaviour);
        TransitionTo(this.trafficLightStateMove);
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