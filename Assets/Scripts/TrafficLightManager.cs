using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TrafficLightManager : MonoBehaviour, IGameControlClickableObject {
    [HideInInspector] public UnityEvent<GameControlTypeManager.TrainLocationType> OnTrafficStatusControl;
    [SerializeField] private GameControlTypeManager.TrainLocationType trafficLightStatus;
    [SerializeField] private float standbySeconds;
    
    public void OnClick() {
        if (this.trafficLightStatus == GameControlTypeManager.TrainLocationType.STOP) {
            return;
        }
        
        this.trafficLightStatus = TrafficLightStatusUpdate(this.trafficLightStatus);
        TrafficLightControl(this.trafficLightStatus);
    }

    private void TrafficLightControl(GameControlTypeManager.TrainLocationType trafficLightStatus) {
        this.OnTrafficStatusControl?.Invoke(trafficLightStatus);

        if (trafficLightStatus == GameControlTypeManager.TrainLocationType.STOP) {
            StartCoroutine(TrafficStandbyCoroutine());
        }
    }

    private IEnumerator TrafficStandbyCoroutine() {
        yield return new WaitForSeconds(this.standbySeconds);
        this.trafficLightStatus = TrafficLightStatusUpdate(this.trafficLightStatus);
        TrafficLightControl(this.trafficLightStatus);
    }
    
    private GameControlTypeManager.TrainLocationType TrafficLightStatusUpdate(GameControlTypeManager.TrainLocationType currentTrainLocationTypeType) {
        currentTrainLocationTypeType += 1;
        
        if ((int)currentTrainLocationTypeType == 3) { 
            currentTrainLocationTypeType = 0;
        }
        
        return currentTrainLocationTypeType;
    }
}