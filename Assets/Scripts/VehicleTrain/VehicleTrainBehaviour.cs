using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class VehicleTrainBehaviour : MonoBehaviour { 
    [SerializeField] private float vehicleMaxSpeed;
    [SerializeField] private float vehicleAcceleration;
    [SerializeField] private float vehicleCurrentSpeed;
    [SerializeField] private int jointCars;
    
    [FormerlySerializedAs("trainTrafficManager")]
    [FormerlySerializedAs("vehicleTrainTrafficManager")]
    [Space(25f)]
    
    [SerializeField] private TrainInformationBoardBehaviour trainInformationBoardBehaviour;
    
    private Transform vehicleTransform;
    private Rigidbody vehicleRigidbody;
    

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
        this.trainInformationBoardBehaviour.TrainSetActive(true);
        
        this.trainInformationBoardBehaviour.onTrafficExecuteMove.AddListener(Move);
        this.trainInformationBoardBehaviour.onTrafficExecuteStop.AddListener(Stop);
        this.trainInformationBoardBehaviour.onTrafficEnterIdle.AddListener(Idle);
    }
    
    private void OnDisable() {
        // 상태를 출발 -> 대기로
        this.trainInformationBoardBehaviour?.TrainSetActive(false);

        this.trainInformationBoardBehaviour?.onTrafficExecuteMove.RemoveListener(Move);
        this.trainInformationBoardBehaviour?.onTrafficExecuteStop.RemoveListener(Stop);
        this.trainInformationBoardBehaviour?.onTrafficEnterIdle.RemoveListener(Idle);
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
            this.trainInformationBoardBehaviour.onTrafficTransitionToIdle.Invoke();
        }
    }
}