public class TrafficStateMachine {
    public ITrafficState CurrentTrafficState { get; private set; }

    public TrafficStateIdle trafficStateIdle;
    public TrafficStateMove trafficStateMove;
    public TrafficStateStop trafficStateStop;


    
    public TrafficStateMachine(TrafficStateBehaviour trafficStateBehaviour) {
        this.trafficStateMove = new (trafficStateBehaviour);
        this.trafficStateStop = new (trafficStateBehaviour);
        this.trafficStateIdle = new (trafficStateBehaviour);
        TransitionTo(this.trafficStateMove);
    }
    
    public void TransitionTo(ITrafficState nextTrafficState) {
        this.CurrentTrafficState?.Exit();
        this.CurrentTrafficState = nextTrafficState;
        this.CurrentTrafficState?.Enter();
    }

    public void Execute() {
        this.CurrentTrafficState?.Execute();
    }
}