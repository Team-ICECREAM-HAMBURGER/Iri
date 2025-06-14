using UnityEngine;

public class VehicleTrainTrafficLightManger : MonoBehaviour {
    [SerializeField] private VehicleTrainTrafficManager vehicleTrainTrafficManager;
    [Space(10f)]
    [SerializeField] private Light trafficLight;
    [Space(10f)] 
    [SerializeField] private Animator animator;
    [SerializeField] private string animationTriggerName;
    
    private Color trafficLightsColorIdle;
    private Color trafficLightsColorMove;
    private Color trafficLightsColorStop;


    private void Init() {
        this.vehicleTrainTrafficManager.onTrafficEnterIdle.AddListener(Idle);
        this.vehicleTrainTrafficManager.onTrafficEnterStop.AddListener(Stop);
        this.vehicleTrainTrafficManager.onTrafficExecuteMove.AddListener(Move);
        
        this.trafficLightsColorIdle = Color.yellow;
        this.trafficLightsColorStop = Color.red;
        this.trafficLightsColorMove = Color.green;
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
        // Debug.Log("정지!");
        this.animator.SetTrigger(this.animationTriggerName);
        this.trafficLight.color = this.trafficLightsColorStop;
    }
}