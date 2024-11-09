using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class VehicleTrainController : MonoBehaviour {
    [Header("Vehicle Component")]
    [field: SerializeField] public GameControlTypeManager.vehicleType VehicleType { get; set; }
    [field: SerializeField] public GameControlTypeManager.TrafficStatus TrafficStatus { get; set; }
    [SerializeField] private GameControlDictionary.TrafficStatusText trafficStatusText;
    [SerializeField] private GameObject engineCar;
    [SerializeField] private List<GameObject> jointCars;

    [Space(25f)]
    
    [Header("Game System Component")]
    public TrafficLightManager trafficLightManager;
    public TrafficStatusTrigger trafficApproachTrigger;
    public TrafficStatusTrigger trafficPassTrigger;
    public TrainSpawnController trainSpawnController;
    
    [Space(25f)]
    
    [Header("Vehicle Setting")]
    [SerializeField] private float vehicleMaxSpeed;            // 80 km/h
    [SerializeField] private float vehicleApproachSpeed;
    [SerializeField] private float vehicleAcceleration;        // 15 km/h
    
    public float VehicleCurrentSpeed { get; private set; }     // n km/h
    public VehicleTrainStateMachine VehicleStateMachine { get; private set; }

    private Transform vehicleTransform;
    private Rigidbody vehicleRigidbody;
    private List<Vector3> jointCarResetPositions;
    private Vector3 engineCarResetPosition;


    private void Init() {
        this.vehicleTransform = this.engineCar.transform;
        this.vehicleRigidbody = this.engineCar.GetComponent<Rigidbody>();
        this.VehicleStateMachine = new VehicleTrainStateMachine(this);
        
        this.vehicleMaxSpeed /= 3.6f;       // km/h -> m/s
        this.vehicleApproachSpeed = (this.vehicleMaxSpeed * 0.9f);
        this.vehicleAcceleration /= 3.6f;   // km/h -> m/s
        
        this.engineCarResetPosition = this.engineCar.transform.localPosition;
        this.jointCarResetPositions = this.jointCars.Select(car => car.transform.localPosition).ToList();
        
        this.VehicleStateMachine?.Init(this.VehicleStateMachine.vehicleTrainStateIdle);
        
        this.trafficLightManager.OnTrafficStatusControl.AddListener(OnTrafficStatusUpdate);

        // TODO: 중복 코드 정리
        this.trafficApproachTrigger.OnTrafficApproach.AddListener(OnTrafficStatusUpdate);
        this.trafficPassTrigger.OnTrafficApproach.AddListener(OnTrafficStatusUpdate);
        
        this.trainSpawnController.OnTransformReset.AddListener(OnTransformReset);
    }

    private void Awake() {
        Init();
    }

    private void OnEnable() {
        OnTrafficStatusUpdate(this.TrafficStatus);
    }

    private void OnDisable() {
        OnTrafficStatusUpdate(GameControlTypeManager.TrafficStatus.MOVE);
        
        this.vehicleRigidbody.linearVelocity = Vector3.zero;
        this.trafficApproachTrigger.OnTriggerSwitch?.Invoke();
        this.trafficPassTrigger.OnTriggerSwitch?.Invoke();
    }

    private void FixedUpdate() {
        this.VehicleStateMachine?.Execute();
    }

    private void OnTrafficStatusUpdate(GameControlTypeManager.TrafficStatus trafficStatusType) {
        this.TrafficStatus = trafficStatusType;
        TrainInformationMonitor.OnTrafficStatusUpdate.Invoke(this.VehicleType, this.TrafficStatus, this.trafficStatusText[this.TrafficStatus]);
    }

    private void OnTransformReset() {
        this.engineCar.transform.SetLocalPositionAndRotation(this.engineCarResetPosition, Quaternion.identity);
        
        for (var i = 0; i < this.jointCars.Count(); i++) {
            this.jointCars[i].transform.SetLocalPositionAndRotation(this.jointCarResetPositions[i], Quaternion.identity);
        }
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

    public void Approach() {
        this.VehicleCurrentSpeed = this.vehicleRigidbody.linearVelocity.magnitude;
        
        if (this.VehicleCurrentSpeed < this.vehicleApproachSpeed) {
            this.vehicleRigidbody.AddForce(this.vehicleTransform.forward * (this.vehicleAcceleration * this.vehicleRigidbody.mass * this.jointCars.Count), ForceMode.Force);    // Acceleration(m/s) * deltaTime * Mass 
        }
        else {
            this.vehicleRigidbody.linearVelocity = this.vehicleRigidbody.linearVelocity.normalized * Mathf.Lerp(this.VehicleCurrentSpeed, this.vehicleApproachSpeed, 0.5f);
        }
        // Move();
    }

    public void Pass() {
        Move();
    }
}