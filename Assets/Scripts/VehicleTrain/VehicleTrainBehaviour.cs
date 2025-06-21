using System;
using UnityEditor;
using UnityEngine;

public class VehicleTrainBehaviour : MonoBehaviour { 
    [SerializeField] private float vehicleMaxSpeed;
    [SerializeField] private float vehicleAcceleration;
    [SerializeField] private float vehicleCurrentSpeed;
    [SerializeField] private int jointCars;
    
    [Space(25f)]
    
    [SerializeField] private VehicleTrainTrafficManager vehicleTrainTrafficManager;
    
    private Transform vehicleTransform;
    private Rigidbody vehicleRigidbody;
    
    private bool isQuit;

    
    private void OnApplicationQuit() {
        this.isQuit = true;
    }
    
    private void Init() {
        // Train Component Init //
        this.vehicleTransform = this.gameObject.transform;
        this.vehicleRigidbody = this.gameObject.GetComponent<Rigidbody>();
        
        this.vehicleMaxSpeed /= 3.6f;       // km/h -> m/s
        this.vehicleAcceleration /= 3.6f;   // km/h -> m/s
    }

    private void Awake() {
        Init();
    }

    private void OnEnable() {
        // 상태를 대기 -> 출발로
        this.vehicleTrainTrafficManager.TrainSetActive(true);
        
        this.vehicleTrainTrafficManager.onTrafficExecuteMove.AddListener(Move);
        this.vehicleTrainTrafficManager.onTrafficExecuteStop.AddListener(Stop);
        this.vehicleTrainTrafficManager.onTrafficEnterIdle.AddListener(Idle);
    }
    
    private void OnDisable() {
#if UNITY_EDITOR
        if (!Application.isPlaying) {
            return;
        }
#endif
        if (GameControlApplicationQuitChecker.IsQuit) {
            return;
        }
        
        // 상태를 출발 -> 대기로
        this.vehicleTrainTrafficManager?.TrainSetActive(false);

        this.vehicleTrainTrafficManager?.onTrafficExecuteMove.RemoveListener(Move);
        this.vehicleTrainTrafficManager?.onTrafficExecuteStop.RemoveListener(Stop);
        this.vehicleTrainTrafficManager?.onTrafficEnterIdle.RemoveListener(Idle);
    }

    private void Idle() {
        this.vehicleRigidbody.linearVelocity = Vector3.zero;
    }
    
    private void Move() {
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
        var speed = this.vehicleRigidbody.linearVelocity.magnitude;

        if (speed > 1f) {
            var brakeForce = -this.vehicleRigidbody.linearVelocity.normalized 
                                 * (this.vehicleAcceleration * this.vehicleRigidbody.mass);
            this.vehicleRigidbody.AddForce(brakeForce, ForceMode.Force);
        }
        else {
            this.vehicleRigidbody.linearVelocity = Vector3.zero;
            this.vehicleTrainTrafficManager.onTrafficTransitionToIdle.Invoke();
        }
    }
}