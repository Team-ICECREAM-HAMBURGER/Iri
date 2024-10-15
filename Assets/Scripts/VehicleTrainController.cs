using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VehicleTrainController : MonoBehaviour {
    [Header("Vehicle Component")]
    [SerializeField] private GameControlTypeManager.TrainType trainType;
    [SerializeField] private GameControlTypeManager.TrainStatus trainStatus;
    [SerializeField] private GameObject engineCar;
    [SerializeField] private List<GameObject> jointCars;
    
    [Space(25f)]
    
    [Header("Vehicle Setting")]
    [SerializeField] private float vehicleCurrentSpeed;     // n km/h
    [SerializeField] private float vehicleMaxSpeed;         // 80 km/h
    [SerializeField] private float vehicleAcceleration;     // 15 km/h
    
    private Transform vehicleTransform;
    private Rigidbody vehicleRigidbody;
    
    
    private void Init() {
        this.vehicleMaxSpeed /= 3.6f;       // km/h -> m/s
        this.vehicleAcceleration /= 3.6f;   // km/h -> m/s
        
        this.vehicleTransform = this.engineCar.transform;
        this.vehicleRigidbody = this.engineCar.GetComponent<Rigidbody>();
    }

    private void Awake() {
        Init();
    }

    private void Start() {
        
    }

    private void Update() {
        
    }

    private void FixedUpdate() {
        VehicleEngineControl();
    }

    private void VehicleEngineControl() {
        this.vehicleCurrentSpeed = this.vehicleRigidbody.velocity.magnitude;    // Current Speed (velocity Magnitude)
        
        if (this.vehicleCurrentSpeed < this.vehicleMaxSpeed) {
            this.vehicleRigidbody.AddForce(this.vehicleTransform.forward * (this.vehicleAcceleration * this.vehicleRigidbody.mass * this.jointCars.Count), ForceMode.Force);    // Acceleration(m/s) * deltaTime * Mass 
        }
        else {
            this.vehicleRigidbody.velocity = this.vehicleRigidbody.velocity.normalized * this.vehicleMaxSpeed;
        }
    }
}