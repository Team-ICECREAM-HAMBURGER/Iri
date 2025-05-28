using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VehicleTrainBehaviour : MonoBehaviour { 
    [Header("Train Components")] 
    [SerializeField] private GameObject engineCar;
    [SerializeField] private List<GameObject> jointCars;
    [Space(10f)]
    [SerializeField] private float vehicleMaxSpeed;
    [SerializeField] private float vehicleAcceleration;
    [Space(10f)]
    [SerializeField] private float vehicleCurrentSpeed;
    private Transform vehicleTransform;
    private Rigidbody vehicleRigidbody;
    public List<Vector3> JointCarResetPositions { get; private set; }
    public Vector3 EngineCarResetPosition { get; private set; }
    
    private VehicleTrainStateMachine vehicleStateMachine;
    
    
    private void Init() {
        // Train Component Init //
        this.vehicleTransform = this.engineCar.transform;
        this.vehicleRigidbody = this.engineCar.GetComponent<Rigidbody>();
        
        this.vehicleMaxSpeed /= 3.6f;       // km/h -> m/s
        this.vehicleAcceleration /= 3.6f;   // km/h -> m/s
        
        this.EngineCarResetPosition = this.engineCar.transform.localPosition;
        this.JointCarResetPositions = this.jointCars.Select(car => car.transform.localPosition).ToList();
        
        // StateMachine Init //
        this.vehicleStateMachine = new VehicleTrainStateMachine(this);
    }

    private void Awake() {
        Init();
    }

    private void FixedUpdate() {
        this.vehicleStateMachine?.Execute();
    }

    public void Move() {
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
    
    public void Stop() {
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

    public void Idle() {
        this.vehicleCurrentSpeed = 0f;
    }
}