using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleControlTrain : MonoBehaviour {
    [Header("Vehicle Component")]
    [SerializeField] private GameControlType.TrainType trainType;
    [SerializeField] private GameControlType.TrainStatus trainStatus;
    [SerializeField] private GameObject engineCar;
    [SerializeField] private List<GameObject> jointCars;
    
    [Space(25f)]
    
    [Header("Vehicle Setting")]
    [SerializeField] private float vehicleCurrentSpeed;
    [SerializeField] private float vehicleAcceleration;
    private Vector3 vehiclePosition;


    private void Init() {
        this.vehiclePosition = this.engineCar.transform.position;
    }

    private void Awake() {
        Init();
    }

    private void Start() {
        
    }

    private void Update() {
        
    }

    private void FixedUpdate() {
        
    }
}