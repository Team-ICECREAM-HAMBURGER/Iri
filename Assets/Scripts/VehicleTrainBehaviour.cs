using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class VehicleTrainBehaviour : MonoBehaviour { 
    [Header("Train Components")] 
    [SerializeField] private GameControlTypeManager.VehicleTrainType vehicleType;
    [Space(10f)]
    [SerializeField] private GameObject engineCar;
    [SerializeField] private List<GameObject> jointCars;
    [Space(10f)]
    [SerializeField] private float vehicleMaxSpeed;
    [SerializeField] private float vehicleAcceleration;
    [SerializeField] private float vehicleCurrentSpeed;
    
    [FormerlySerializedAs("trafficLightBehaviour")]
    [Space(25f)]
    
    [Header("System Components")]
    [SerializeField] private TrafficStateBehaviour trafficStateBehaviour;
    
    public List<Vector3> JointCarResetPositions { get; private set; }
    public Vector3 EngineCarResetPosition { get; private set; }
    
    private Transform vehicleTransform;
    private Rigidbody vehicleRigidbody;

    
    private void Init() {
        // Train Component Init //
        this.vehicleTransform = this.engineCar.transform;
        this.vehicleRigidbody = this.engineCar.GetComponent<Rigidbody>();
        
        this.vehicleMaxSpeed /= 3.6f;       // km/h -> m/s
        this.vehicleAcceleration /= 3.6f;   // km/h -> m/s
        
        this.EngineCarResetPosition = this.engineCar.transform.localPosition;
        this.JointCarResetPositions = this.jointCars.Select(car => car.transform.localPosition).ToList();
        
        // Traffic Light Event Listener //
        this.trafficStateBehaviour.OnTrafficUpdateIdle.AddListener(Idle);
        this.trafficStateBehaviour.OnTrafficUpdateMove.AddListener(Move);
        this.trafficStateBehaviour.OnTrafficUpdateStop.AddListener(Stop);
    }

    private void Awake() {
        Init();
    }

    private void Idle() {
        TrainInfoMonitorUpdate(GameControlTypeManager.TrafficState.IDLE);
        this.vehicleCurrentSpeed = 0f;
    }
    
    private void Move() {
        TrainInfoMonitorUpdate(GameControlTypeManager.TrafficState.MOVE);
        this.vehicleCurrentSpeed = this.vehicleRigidbody.linearVelocity.magnitude;
        
        if (this.vehicleCurrentSpeed < this.vehicleMaxSpeed) {
            this.vehicleRigidbody.AddForce(
                this.vehicleTransform.forward 
                * (this.vehicleAcceleration * this.vehicleRigidbody.mass * this.jointCars.Count), ForceMode.Force);
        }
        else {
            this.vehicleRigidbody.linearVelocity 
                = this.vehicleRigidbody.linearVelocity.normalized * this.vehicleMaxSpeed;
        }
    }
    
    private void Stop() {
        TrainInfoMonitorUpdate(GameControlTypeManager.TrafficState.STOP);
        this.vehicleCurrentSpeed = this.vehicleRigidbody.linearVelocity.magnitude;
        
        if (Vector3.Dot(this.vehicleTransform.forward, this.vehicleTransform.up) >= 0.1f) {
            this.vehicleRigidbody.AddForce(
                -this.vehicleTransform.forward 
                * (this.vehicleAcceleration * this.vehicleRigidbody.mass * this.jointCars.Count), ForceMode.Force);
        }
        else {
            this.vehicleCurrentSpeed = 0f;
        }
    }
    
    private void TrainInfoMonitorUpdate(GameControlTypeManager.TrafficState trafficState) {
        TrainInfoMonitorBehaviour.OnTrafficStatusUpdate.Invoke(this.vehicleType, trafficState);
    }
}