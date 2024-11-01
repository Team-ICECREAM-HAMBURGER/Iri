using UnityEngine;

public class TrainInformationStateMachine {
    public ITrainInformationState CurrentTrainInformationState { get; private set; }
    
    public TrainInformationStateMove trainInformationStateMove;
    public TrainInformationStateStop trainInformationStateStop;
    public TrainInformationStateIdle trainInformationStateIdle;


    public TrainInformationStateMachine(VehicleTrainController vehicleTrainController) {
        this.trainInformationStateMove = new(vehicleTrainController);
        this.trainInformationStateStop = new(vehicleTrainController);
        this.trainInformationStateIdle = new(vehicleTrainController);
        
        this.CurrentTrainInformationState = this.trainInformationStateStop;
    }

    public void Init(ITrainInformationState initTrainInformationState) {
        this.CurrentTrainInformationState = initTrainInformationState;
        this.CurrentTrainInformationState?.Enter();
    }

    public void TransitionTo(ITrainInformationState nextTrainInformationState) {
        this.CurrentTrainInformationState?.Exit();
        this.CurrentTrainInformationState = nextTrainInformationState;
        this.CurrentTrainInformationState?.Enter();
    }

    public void Execute() {
        this.CurrentTrainInformationState?.Execute();
    }
}