using UnityEngine;

public class TrafficLightBehaviour : MonoBehaviour {
    [SerializeField] private GameControlTypeManager.VehicleTrainType vehicleTrainType;
    
    
    private void Init() {
        
    }

    private void Awake() {
        Init();
    }

    public void OnTrafficLightUpdate() {
        // TODO: 버튼 클릭 -> 신호 변경(스테이트머신) -> 신호 번경에 따른 이벤트 전파 -> 열차가 이벤트에 반응
    }
}