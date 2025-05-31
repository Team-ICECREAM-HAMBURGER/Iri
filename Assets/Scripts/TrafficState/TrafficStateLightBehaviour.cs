using UnityEngine;

public class TrafficStateLightBehaviour : MonoBehaviour {
    [Header("System Components")]
    [SerializeField] private TrafficStateBehaviour trafficStateBehaviour;
    
    [Space(25f)]
    
    [Header("Traffic Lights")] 
    [SerializeField] private Light trafficLight;
    
    private Color trafficLightsColorIdle;
    private Color trafficLightsColorMove;
    private Color trafficLightsColorStop;


    private void Init() {
        this.trafficLightsColorIdle = Color.yellow;
        this.trafficLightsColorStop = Color.red;
        this.trafficLightsColorMove = Color.green;
        
        this.trafficStateBehaviour.OnTrafficUpdateIdle.AddListener(Idle);
        this.trafficStateBehaviour.OnTrafficUpdateMove.AddListener(Move);
        this.trafficStateBehaviour.OnTrafficUpdateStop.AddListener(Stop);
    }
    
    private void Awake() {
        Init();
    }

    private void Idle() {
        this.trafficLight.color = this.trafficLightsColorIdle;
    }

    private void Move() {
        this.trafficLight.color = this.trafficLightsColorMove;

    }

    private void Stop() {
        this.trafficLight.color = this.trafficLightsColorStop;

    }
}