using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrafficLightController : MonoBehaviour, IGameControlClickableObject {
    [HideInInspector] public UnityEvent<GameControlTypeManager.TrafficStatus> OnTrafficLightControl;
    [SerializeField] private GameControlTypeManager.TrafficStatus trafficLightStatus;
    [SerializeField] private List<Light> trafficLights;

    private Dictionary<GameControlTypeManager.TrafficStatus, Color> trafficLightColors;
    

    private void Init() {
        this.trafficLightColors = new() {
            { GameControlTypeManager.TrafficStatus.MOVE, Color.green },
            { GameControlTypeManager.TrafficStatus.STOP, Color.red },
            { GameControlTypeManager.TrafficStatus.IDLE, Color.yellow }
        };

        foreach (var VARIABLE in this.trafficLights) {
            VARIABLE.color = this.trafficLightColors[this.trafficLightStatus];
        }
    }

    private void Awake() {
        Init();
    }
    
    public void OnClick() {
        this.trafficLightStatus = TrafficLightStatusUpdate(this.trafficLightStatus);

        foreach (var VARIABLE in this.trafficLights) {
            VARIABLE.color = this.trafficLightColors[this.trafficLightStatus];
        }
        
        TrafficLightControl(this.trafficLightStatus);
    }

    private void TrafficLightControl(GameControlTypeManager.TrafficStatus trafficLightStatus) {
        this.OnTrafficLightControl?.Invoke(trafficLightStatus);
    }
    
    private GameControlTypeManager.TrafficStatus TrafficLightStatusUpdate(GameControlTypeManager.TrafficStatus currentTrafficStatusType) {
        currentTrafficStatusType += 1;
        
        if ((int)currentTrafficStatusType >= (Enum.GetValues(typeof(GameControlTypeManager.TrafficStatus)).Length)) {
            currentTrafficStatusType = 0;
        }
        
        foreach (var VARIABLE in this.trafficLights) {
            VARIABLE.color = this.trafficLightColors[this.trafficLightStatus];
        }
        
        return currentTrafficStatusType;
    }
}