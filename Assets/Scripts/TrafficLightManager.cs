using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TrafficLightManager : MonoBehaviour, IGameControlClickableObject {
    [HideInInspector] public UnityEvent<GameControlTypeManager.TrafficStatus> OnTrafficStatusControl;
    [SerializeField] private GameControlTypeManager.TrafficStatus trafficLightStatus;
    [SerializeField] private float standbySeconds;
    
    public void OnClick() {
        if (this.trafficLightStatus == GameControlTypeManager.TrafficStatus.STOP) {
            return;
        }
        
        this.trafficLightStatus = TrafficLightStatusUpdate(this.trafficLightStatus);
        TrafficLightControl(this.trafficLightStatus);
    }

    private void TrafficLightControl(GameControlTypeManager.TrafficStatus trafficLightStatus) {
        this.OnTrafficStatusControl?.Invoke(trafficLightStatus);

        if (trafficLightStatus == GameControlTypeManager.TrafficStatus.STOP) {
            StartCoroutine(TrafficStandbyCoroutine());
        }
    }

    private IEnumerator TrafficStandbyCoroutine() {
        yield return new WaitForSeconds(this.standbySeconds);
        this.trafficLightStatus = TrafficLightStatusUpdate(this.trafficLightStatus);
        TrafficLightControl(this.trafficLightStatus);
    }
    
    private GameControlTypeManager.TrafficStatus TrafficLightStatusUpdate(GameControlTypeManager.TrafficStatus currentTrafficStatusType) {
        currentTrafficStatusType += 1;
        
        if ((int)currentTrafficStatusType == 3) { 
            currentTrafficStatusType = 0;
        }
        
        return currentTrafficStatusType;
    }
}