using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleTrainController : MonoBehaviour {
    [Header("Vehicle Component")]
    [field: SerializeField] public GameControlTypeManager.vehicleType VehicleType { get; set; }
    [field: SerializeField] public GameControlTypeManager.TrafficStatus TrafficStatus { get; set; }
    [SerializeField] private GameObject engineCar;
    [SerializeField] private List<GameObject> jointCars;
    public TrafficLightManager trafficLightManager;
    
    [Header("Vehicle Setting")]
    public float VehicleCurrentSpeed { get; private set; }     // n km/h
    [SerializeField] private float vehicleMaxSpeed;            // 80 km/h
    [SerializeField] private float vehicleAcceleration;        // 15 km/h
    
    public VehicleTrainStateMachine VehicleStateMachine { get; private set; }
    private Transform vehicleTransform;
    private Rigidbody vehicleRigidbody;
    
    
    private void Init() {
        this.vehicleTransform = this.engineCar.transform;
        this.vehicleRigidbody = this.engineCar.GetComponent<Rigidbody>();
        this.VehicleStateMachine = new VehicleTrainStateMachine(this);
        
        this.vehicleMaxSpeed /= 3.6f;       // km/h -> m/s
        this.vehicleAcceleration /= 3.6f;   // km/h -> m/s
        
        this.VehicleStateMachine?.Init(this.VehicleStateMachine.vehicleTrainStateIdle);
        this.trafficLightManager.OnTrafficStatusControl.AddListener(OnTrafficStatusUpdate);
    }

    private void Awake() {
        Init();
    }

    private void FixedUpdate() {
        this.VehicleStateMachine?.Execute();
    }

    private void OnTrafficStatusUpdate(GameControlTypeManager.TrafficStatus trafficStatusType) {
        this.TrafficStatus = trafficStatusType;
    }
    
    public void Move() {
        this.VehicleCurrentSpeed = this.vehicleRigidbody.linearVelocity.magnitude;
        
        if (this.VehicleCurrentSpeed < this.vehicleMaxSpeed) {
            this.vehicleRigidbody.AddForce(this.vehicleTransform.forward * (this.vehicleAcceleration * this.vehicleRigidbody.mass * this.jointCars.Count), ForceMode.Force);    // Acceleration(m/s) * deltaTime * Mass 
        }
        else {
            this.vehicleRigidbody.linearVelocity = this.vehicleRigidbody.linearVelocity.normalized * this.vehicleMaxSpeed;
        }
    }

    public void Stop() {
        this.VehicleCurrentSpeed = this.vehicleRigidbody.linearVelocity.magnitude;
        
        if (Vector3.Dot(this.vehicleTransform.forward, this.vehicleTransform.up) >= 0.1f) {     // Vector's Inner Product
            this.vehicleRigidbody.AddForce(-this.vehicleTransform.forward * (this.vehicleAcceleration * this.vehicleRigidbody.mass * this.jointCars.Count), ForceMode.Force);    // Acceleration(m/s) * deltaTime * Mass
        }
        else {
            this.VehicleCurrentSpeed = 0f;
        }
    }
    
    public void Idle() {
        this.VehicleCurrentSpeed = 0f;
    }
}