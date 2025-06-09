using System;
using UnityEngine;

public class VehicleTrainInvestigationBehaviour : MonoBehaviour {
    [SerializeField] private VehicleTrainTrafficManager vehicleTrainTrafficManager;
    
    
    private void Init() {
        this.vehicleTrainTrafficManager.onTrafficEnterIdle.AddListener(OnInvestigationTalk);    
    }

    private void Awake() {
        Init();
    }

    private void OnInvestigationTalk() {
        Debug.Log("Talking...");
    }
}