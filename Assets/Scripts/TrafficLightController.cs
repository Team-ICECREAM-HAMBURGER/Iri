using UnityEngine;

public class TrafficLightController : MonoBehaviour {
    [Header("Traffic Light Component")]
    [field:SerializeField] public GameControlTypeManager.TrainLocationType TrafficLightStatus { get; set; }
    [SerializeField] private TrafficLightManager trafficLightManager;

    [Header("Traffic Light Setting")] 
    [SerializeField] private Color moveLightColor;
    [SerializeField] private Color stopLightColor;
    [SerializeField] private Color idleLightColor;
    
    public TrafficLightStateMachine TrafficLightStateMachine { get; private set; }

    private Light trafficLight;
    
    
    private void Init() {
        this.trafficLight = this.gameObject.GetComponent<Light>();
        
        this.TrafficLightStateMachine = new TrafficLightStateMachine(this);
        this.TrafficLightStateMachine?.Init(this.TrafficLightStateMachine.trafficLightStateIdle);
        this.trafficLightManager.OnTrafficStatusControl.AddListener(OnTrafficLightStatusUpdate);
    }

    private void Awake() {
        Init();
    }

    private void Update() {
        this.TrafficLightStateMachine?.Execute();
    }
    
    private void OnTrafficLightStatusUpdate(GameControlTypeManager.TrainLocationType trafficLightStatusType) {
        this.TrafficLightStatus = trafficLightStatusType;
    }
    
    public void Move() {
        this.trafficLight.color = this.moveLightColor;
    }

    public void Stop() {
        this.trafficLight.color = this.stopLightColor;
    }

    public void Idle() {
        this.trafficLight.color = this.idleLightColor;
    }
}
