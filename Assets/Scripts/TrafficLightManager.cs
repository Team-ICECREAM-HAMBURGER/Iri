using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TrafficLightManager : MonoBehaviour, IGameControlClickableObject {
    [HideInInspector] public UnityEvent<GameControlTypeManager.TrafficState> OnTrafficStatusControl;
    [FormerlySerializedAs("trafficLightStatus")] [SerializeField] private GameControlTypeManager.TrafficState trafficLightState;
    [SerializeField] private float standbySeconds;
    
    public void OnClick() {
        if (this.trafficLightState == GameControlTypeManager.TrafficState.STOP) {
            return;
        }
        
        this.trafficLightState = TrafficLightStatusUpdate(this.trafficLightState);
        TrafficLightControl(this.trafficLightState);
    }

    private void TrafficLightControl(GameControlTypeManager.TrafficState trafficLightState) {
        this.OnTrafficStatusControl?.Invoke(trafficLightState);

        if (trafficLightState == GameControlTypeManager.TrafficState.STOP) {
            StartCoroutine(TrafficStandbyCoroutine());
        }
    }

    private IEnumerator TrafficStandbyCoroutine() {
        yield return new WaitForSeconds(this.standbySeconds);
        this.trafficLightState = TrafficLightStatusUpdate(this.trafficLightState);
        TrafficLightControl(this.trafficLightState);
    }
    
    private GameControlTypeManager.TrafficState TrafficLightStatusUpdate(GameControlTypeManager.TrafficState currentTrafficStateType) {
        currentTrafficStateType += 1;
        
        if ((int)currentTrafficStateType == (int)GameControlTypeManager.TrafficState.APPROACH) {
            currentTrafficStateType = 0;
        }
        
        return currentTrafficStateType;
    }
}