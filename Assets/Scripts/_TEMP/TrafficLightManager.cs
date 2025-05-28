using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TrafficLightManager : MonoBehaviour, IGameControlClickableObject {
    [HideInInspector] public UnityEvent<GameControlTypeManager.TrafficState> OnTrafficStatusControl;
    
    [SerializeField] private GameControlTypeManager.TrafficState trafficLightState;
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
    
    private GameControlTypeManager.TrafficState TrafficLightStatusUpdate(
        GameControlTypeManager.TrafficState currentTrafficStateType) {
        currentTrafficStateType += 1;
        
        if ((int)currentTrafficStateType == (int)GameControlTypeManager.TrafficState.IDLE) {
            currentTrafficStateType = 0;
        }
        
        return currentTrafficStateType;
    }
}