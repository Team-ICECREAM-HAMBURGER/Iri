using System.Collections.Generic;
using UnityEngine;

public class VehicleTrainBehaviour : MonoBehaviour { 
    [SerializeField] private float vehicleMaxSpeed;
    [SerializeField] private float vehicleAcceleration;
    [SerializeField] private float vehicleCurrentSpeed;
    [SerializeField] private int jointCars;
    
    [Space(25f)]
    
    [SerializeField] private TrafficStateBehaviour trafficStateBehaviour;
    
    private Transform vehicleTransform;
    private Rigidbody vehicleRigidbody;

    
    private void Init() {
        // Train Component Init //
        this.vehicleTransform = this.gameObject.transform;
        this.vehicleRigidbody = this.gameObject.GetComponent<Rigidbody>();
        
        this.vehicleMaxSpeed /= 3.6f;       // km/h -> m/s
        this.vehicleAcceleration /= 3.6f;   // km/h -> m/s
       
        // Traffic Light Event Listener //
        this.trafficStateBehaviour.OnTrafficUpdateIdle.AddListener(Idle);
        this.trafficStateBehaviour.OnTrafficUpdateMove.AddListener(Move);
        this.trafficStateBehaviour.OnTrafficUpdateStop.AddListener(Stop);
    }

    private void Awake() {
        Init();
    }

    private void Idle() {
        // TrainInfoMonitorUpdate(GameControlTypeManager.TrafficState.IDLE);
        this.vehicleCurrentSpeed = 0f;
    }
    
    private void Move() {
        // TrainInfoMonitorUpdate(GameControlTypeManager.TrafficState.MOVE);
        this.vehicleCurrentSpeed = this.vehicleRigidbody.linearVelocity.magnitude;
        
        if (this.vehicleCurrentSpeed < this.vehicleMaxSpeed) {
            this.vehicleRigidbody.AddForce(
                this.vehicleTransform.forward 
                * (this.vehicleAcceleration * this.vehicleRigidbody.mass * this.jointCars), ForceMode.Force);
        }
        else {
            this.vehicleRigidbody.linearVelocity 
                = this.vehicleRigidbody.linearVelocity.normalized * this.vehicleMaxSpeed;
        }
    }
    
    private void Stop() {
        // TrainInfoMonitorUpdate(GameControlTypeManager.TrafficState.STOP);
        this.vehicleCurrentSpeed = this.vehicleRigidbody.linearVelocity.magnitude;
        
        if (Vector3.Dot(this.vehicleTransform.forward, this.vehicleTransform.up) >= 0.1f) {
            this.vehicleRigidbody.AddForce(
                -this.vehicleTransform.forward 
                * (this.vehicleAcceleration * this.vehicleRigidbody.mass * this.jointCars), ForceMode.Force);
        }
        else {
            this.vehicleCurrentSpeed = 0f;
        }
    }
    
    // private void TrainInfoMonitorUpdate(GameControlTypeManager.TrafficState trafficState) {
    //     TrainInfoMonitorBehaviour.OnTrafficStatusUpdate.Invoke(this.vehicleType, trafficState);
    // }
}